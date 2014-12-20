using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Windows.Forms;
using System.Configuration.Install;
using System.Collections;
using Microsoft.Win32;
using System.IO;
using System.Security.Principal;
using System.Diagnostics;
using System.Reflection;

namespace SyncThingTray
{
	static class Program
	{
		public const string SERVICENAME = "SyncThingService";
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] Args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if (Args.Length > 0)
			{
				if (Args[0].ToLower() == "install")
				{
					if (!IsUserAdministrator) { RunAsAdministrator(Args); return; }
					InstallService();
					return;
				}
				else if (Args[0].ToLower() == "uninstall")
				{
					if (!IsUserAdministrator) { RunAsAdministrator(Args); return; }
					UninstallService();
					return;
				}
				else if (Args[0].ToLower() == "start")
				{
					if (!IsUserAdministrator) { RunAsAdministrator(Args); return; }
					StartService();
					return;
				}
				else if (Args[0].ToLower() == "stop")
				{
					if (!IsUserAdministrator) { RunAsAdministrator(Args); return; }
					StopService();
					return;
				}
				else if (Args[0].ToLower() == "configure")
				{
					if (!IsUserAdministrator) { RunAsAdministrator(Args); return; }
					var f = new frmInstall();
					f.SetForm();
					Application.Run(f);
					return;
				}
			}
			if (Environment.UserInteractive)
				Application.Run(new frmMain());
			else
				ServiceBase.Run(new SyngThingService());
		}

		public static bool IsInstalled { get { using (ServiceController s = new ServiceController(SERVICENAME)) return GetIsInstalled(s); } }
		public static bool GetIsInstalled(ServiceController Controller)
		{
			try { var status = Controller.Status; }
			catch { return false; }
			return true;
		}

		public static bool IsRunning { get { using (ServiceController s = new ServiceController(SERVICENAME)) return GetIsRunning(s); } }
		public static bool GetIsRunning(ServiceController Controller)
		{
			if (!GetIsInstalled(Controller)) return false;
			return Controller.Status == ServiceControllerStatus.Running;
		}

		public static void InstallService()
		{
			InstallService(ServiceStartMode.Automatic,false, ServiceAccount.LocalSystem, null, null);
		}

		public static void InstallService(ServiceStartMode StartMode,bool DelayedStart, ServiceAccount Account, string UserName, string Password)
		{
			if (IsInstalled) return;
			try
			{
				string path = "/assemblypath=" + Assembly.GetEntryAssembly().Location;
				using (var iGbl = new TransactedInstaller())
				using (var iSP = new System.ServiceProcess.ServiceProcessInstaller())
				using (var iS = new System.ServiceProcess.ServiceInstaller())
				{
					iSP.Account = Account;
					iSP.Password = Password;
					iSP.Username = UserName;
					iS.Description = "Start the SyncThing executable in the background and allow monitoring";
					iS.DisplayName = "SyncThing synchronization launcher";
					iS.ServiceName = "SyncThingService";
					iS.StartType = StartMode;
					iS.DelayedAutoStart = DelayedStart;
					iGbl.Installers.AddRange(new System.Configuration.Install.Installer[] { iSP, iS });
					iGbl.Context = new InstallContext(null, new[] { path });
					iGbl.Install(new Hashtable());
				}
			}
			catch { throw; }
		}

		public static void UninstallService()
		{
			if (!IsInstalled) return;
			try
			{
				string path = "/assemblypath=" + Assembly.GetEntryAssembly().Location;
				using (var iGbl = new TransactedInstaller())
				using (var iSP = new System.ServiceProcess.ServiceProcessInstaller())
				using (var iS = new System.ServiceProcess.ServiceInstaller())
				{
					iS.ServiceName = "SyncThingService";
					iGbl.Installers.AddRange(new System.Configuration.Install.Installer[] { iSP, iS });
					iGbl.Context = new InstallContext(null, new[] { path });
					iGbl.Uninstall(null);
				}
			}
			catch { throw; }
		}

		public static void StartService()
		{
			if (!IsUserAdministrator) { RunAsAdministrator("start"); return; }
			using (ServiceController controller =
					new ServiceController(SERVICENAME))
			{
				if (!GetIsInstalled(controller)) return;
				try
				{
					if (controller.Status != ServiceControllerStatus.Running)
					{
						controller.Start();
						controller.WaitForStatus(ServiceControllerStatus.Running,
								TimeSpan.FromSeconds(10));

					}
				}
				catch { throw; }
			}
		}

		public static void StopService()
		{
			if (!IsUserAdministrator) { RunAsAdministrator("stop"); return; }
			using (ServiceController controller =
					new ServiceController(SERVICENAME))
			{
				if (!GetIsInstalled(controller)) return;
				try
				{
					if (controller.Status != ServiceControllerStatus.Stopped)
					{
						controller.Stop();
						controller.WaitForStatus(ServiceControllerStatus.Stopped,
								 TimeSpan.FromSeconds(10));
					}
				}
				catch { throw; }
			}
		}

		public static bool IsUserAdministrator
		{
			get
			{
				try
				{
					WindowsIdentity user = WindowsIdentity.GetCurrent();
					WindowsPrincipal principal = new WindowsPrincipal(user);
					return principal.IsInRole(WindowsBuiltInRole.Administrator);
				}
				catch (UnauthorizedAccessException) { return false; }
				catch (Exception) { return false; }
			}
		}

		public static void RunAsAdministrator()
		{
			ProcessStartInfo sinfo = new ProcessStartInfo(Application.ExecutablePath);
			sinfo.Verb = "runas";
			Process.Start(sinfo);
		}

		public static void RunAsAdministrator(params string[] Params)
		{
			ProcessStartInfo sinfo = new ProcessStartInfo(Application.ExecutablePath, "\"" + string.Join("\" \"", Params) + "\"");
			sinfo.Verb = "runas";
			Process.Start(sinfo);
		}

		public static string MonitorFile { get; private set; }
		public static string SyncExePath { get; private set; }
		public static string SyncConfigPath { get; private set; }
		public static ProcessPriorityClass SyncPriority { get; private set; }

		public static bool IsConfigured
		{
			get
			{
				MonitorFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData, Environment.SpecialFolderOption.Create);
				MonitorFile = Path.Combine(MonitorFile, "Syncthing Service");
				if (!Directory.Exists(MonitorFile)) Directory.CreateDirectory(MonitorFile);
				MonitorFile = Path.Combine(MonitorFile, "Std.out");
				
				// Check the configuration
				RegistryKey klm = Registry.LocalMachine;
				if (klm == null) return false;
				using (RegistryKey ksoft = klm.OpenSubKey("SOFTWARE"))
				{
					if (ksoft == null) return false;
					using (RegistryKey ksync = ksoft.OpenSubKey("Syncthing Service"))
					{
						if (ksync == null) return false;
						SyncExePath = ksync.GetValue("Executable", "") as string;
						SyncConfigPath = ksync.GetValue("Configuration", "") as string;
						string priority = ksync.GetValue("Priority", "") as string;
						switch (priority)
						{
							case "Real Time": SyncPriority = ProcessPriorityClass.RealTime; break;
							case "High": SyncPriority = ProcessPriorityClass.High; break;
							case "Above Normal": SyncPriority = ProcessPriorityClass.AboveNormal; break;
							case "Normal": SyncPriority = ProcessPriorityClass.Normal; break;
							case "Below Normal": SyncPriority = ProcessPriorityClass.BelowNormal; break;
							case "Idle": SyncPriority = ProcessPriorityClass.Idle; break;
							default: SyncPriority = ProcessPriorityClass.Normal; break;
						}
						return !string.IsNullOrEmpty(SyncExePath) && !string.IsNullOrEmpty(SyncConfigPath);
					}
				}
			}
		}
	}
}
