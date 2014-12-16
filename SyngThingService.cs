using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace SyncThingTray
{
	public partial class SyngThingService : ServiceBase
	{
		Process syncthing;
		public SyngThingService()
		{
			InitializeComponent();
		}

		public void TestStart() { OnStart(null); }

		protected override void OnStart(string[] args)
		{
			if (Program.IsConfigured)
			{
				ProcessStartInfo pinfo = new ProcessStartInfo(Program.SyncExePath, "-home=\"" + Program.SyncConfigPath + "\"");
				pinfo.WindowStyle = ProcessWindowStyle.Hidden;
				pinfo.RedirectStandardOutput = true;
				pinfo.UseShellExecute = false;
				syncthing = new Process();
				syncthing.EnableRaisingEvents = true;
				syncthing.OutputDataReceived += syncthing_OutputDataReceived;
				syncthing.Exited += syncthing_Exited;
				syncthing.StartInfo = pinfo;
				syncthing.Start();
				syncthing.BeginOutputReadLine();
			}
		}

		void syncthing_Exited(object sender, EventArgs e)
		{
			Stop();
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
				syncthing.Kill();
				foreach (var proc in Process.GetProcesses().Where(p => p.StartInfo.FileName == Program.SyncExePath))
					if (!proc.HasExited)
						proc.Kill();
			}
			syncthing.Dispose();
			File.Delete(Program.MonitorFile);
		}
	}
}
