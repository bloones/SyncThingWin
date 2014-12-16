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
					InstallService();
					return;
				}
				else if (Args[0].ToLower() == "uninstall")
				{
					UninstallService();
					return;
				}
				else if (Args[0].ToLower() == "start")
				{
					StartService();
					return;
				}
				else if (Args[0].ToLower() == "stop")
				{
					StopService();
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

		static AssemblyInstaller GetInstaller()
		{
			AssemblyInstaller installer = new AssemblyInstaller(
					typeof(SyngThingService).Assembly, null);
			installer.UseNewContext = true;
			return installer;
		}

		public static void InstallService()
		{
			if (IsInstalled) return;
			try
			{
				using (AssemblyInstaller installer = GetInstaller())
				{
					IDictionary state = new Hashtable();
					try
					{
						installer.Install(state);
						installer.Commit(state);
					}
					catch
					{
						try { installer.Rollback(state); }
						catch { } throw;
					}
				}
			}
			catch { throw; }
		}

		public static void UninstallService()
		{
			if (!IsInstalled) return;
			try
			{
				using (AssemblyInstaller installer = GetInstaller())
				{
					IDictionary state = new Hashtable();
					try { installer.Uninstall(state); }
					catch { throw; }
				}
			}
			catch { throw; }
		}

		public static void StartService()
		{
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
						return !string.IsNullOrEmpty(SyncExePath) && !string.IsNullOrEmpty(SyncConfigPath);
					}
				}
			}
		}

	}
}
