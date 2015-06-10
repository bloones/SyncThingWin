using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Xml;

namespace SyncThingTray
{
	public partial class SyngThingService : ServiceBase
	{
		Process syncthing;
		List<DateTime> shutdowns;
		public SyngThingService()
		{
			InitializeComponent();
		}

		public void TestStart() { OnStart(null); }

		protected override void OnStart(string[] args)
		{
			if (Program.IsConfigured)
			{
				shutdowns = null;
				StartSyncThing();
			}
		}

		void StartSyncThing()
		{
			ProcessStartInfo pinfo = new ProcessStartInfo(Program.SyncExePath, "-home=\"" + Program.SyncConfigPath + "\"");
			pinfo.WindowStyle = ProcessWindowStyle.Hidden;
			pinfo.RedirectStandardOutput = true;
			pinfo.RedirectStandardInput = true;
			pinfo.UseShellExecute = false;
			syncthing = new Process();
			syncthing.EnableRaisingEvents = true;
			syncthing.OutputDataReceived += syncthing_OutputDataReceived;
			syncthing.Exited += syncthing_Exited;
			syncthing.StartInfo = pinfo;
			syncthing.Start();
			syncthing.BeginOutputReadLine();
			syncthing.PriorityClass = Program.SyncPriority;
		}

		void syncthing_Exited(object sender, EventArgs e)
		{
			string reason;
			if (Program.AutoRestart)
			{
				if (Program.AutoRestartCount > 0)
				{
					if (shutdowns == null) shutdowns = new List<DateTime>();
					shutdowns.Add(DateTime.Now);
					shutdowns.RemoveAll(d => d < (DateTime.Now - Program.AutoRestartPeriod));
					reason = shutdowns.Count <= Program.AutoRestartCount ? null : "The maximum number of shutdown has been reached";
				}
				else
					reason = null;
			}
			else
				reason = "The service is not configured to restart";
			if (reason == null)
			{
				EventLog.WriteEntry("Syncthing has stopped and is being restarted", EventLogEntryType.Warning);
				syncthing.OutputDataReceived -= syncthing_OutputDataReceived;
				syncthing.Exited -= syncthing_Exited;
				syncthing.Dispose();
				StartSyncThing();
			}
			else
			{
				EventLog.WriteEntry("Syncthing has stopped and will not be restarted:\n" + reason, EventLogEntryType.Warning);
				Stop();
			}
		}

		void syncthing_OutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			File.AppendAllLines(Program.MonitorFile, new string[] { e.Data });
		}

		protected override void OnStop()
		{
			if (!syncthing.HasExited)
			{
				syncthing.CancelOutputRead();
				syncthing.OutputDataReceived -= syncthing_OutputDataReceived;
				syncthing.Exited -= syncthing_Exited;

				var res = ShutdownProgram();
				if (res == null)
				{
					syncthing.WaitForExit(2000);
				}
				else
				{
					this.EventLog.WriteEntry("An error occurred when trying to shutdown the syncthing.exe process.\n" + res, EventLogEntryType.Error);
				}

				if (!syncthing.HasExited)
				{
					try
					{
						StopProgram(syncthing);
					}
					catch (Exception x)
					{
						this.EventLog.WriteEntry("An error occurred when trying to stop the syncthing.exe process.\nException: (" + x.GetType().ToString() + ") " + x.Message, EventLogEntryType.Error);
					}
					if (!syncthing.HasExited)
					{
						syncthing.Kill();
						foreach (var proc in Process.GetProcesses().Where(p => p.StartInfo.FileName == Program.SyncExePath))
							if (!proc.HasExited)
								proc.Kill();
						this.EventLog.WriteEntry("The syncthing.exe process could not be stopped gracefully and had to be killed", EventLogEntryType.Error);
						syncthing.WaitForExit(1500);
					}
					else
						this.EventLog.WriteEntry("The syncthing.exe process could not be shutdown and had to be closed gracefully", EventLogEntryType.Warning);
				}
			}
			syncthing.Dispose();
			File.Delete(Program.MonitorFile);
		}

		enum CtrlTypes : uint
		{
			CTRL_C_EVENT = 0,
			CTRL_BREAK_EVENT,
			CTRL_CLOSE_EVENT,
			CTRL_LOGOFF_EVENT = 5,
			CTRL_SHUTDOWN_EVENT
		}

		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GenerateConsoleCtrlEvent(CtrlTypes dwCtrlEvent, uint dwProcessGroupId);
		[DllImport("kernel32.dll", SetLastError = true)]
		static extern bool AttachConsole(uint dwProcessId);
		[DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
		static extern bool FreeConsole();
		[DllImport("Kernel32")]
		private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);


		static void StopProgram(Process proc)
		{
			if (AttachConsole((uint)proc.Id))
			{
				SetConsoleCtrlHandler(null, true);
				GenerateConsoleCtrlEvent(CtrlTypes.CTRL_C_EVENT, 0);
				proc.WaitForExit(2000);
				FreeConsole();
				SetConsoleCtrlHandler(null, false);
			}
		}

		static string ShutdownProgram()
		{
			string res= Program.ReadConfiguration();
			if (res != null) return res;
			var apires = API.CallAPIPost("shutdown");
			if (!apires.Wait(2000)) return null;
			return apires.Result;
		}

	}
}
