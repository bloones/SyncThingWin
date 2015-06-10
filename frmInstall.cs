﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SyncThingTray
{
	public partial class frmInstall : Form
	{
		bool installed = false;

		public frmInstall()
		{
			InitializeComponent();
		}

		public static bool TryInstall()
		{
			if (!Program.IsUserAdministrator) { Program.RunAsAdministrator(); return false; }
			frmInstall frm = new frmInstall();
			frm.SetForm();

			frm.ShowDialog();
			return frm.installed;
		}

		public void SetForm()
		{

			if (Program.IsInstalled)
			{
				txtCurrent.Enabled = false;
				cmbAccount.Enabled = false;
				cmbStartup.Enabled = false;
			}
			else
			{
				btnUninstall.Enabled = false;
				cmbAccount.SelectedItem = "Local System";
				cmbStartup.SelectedItem = "Automatic";
			}
			if (Program.IsConfigured)
			{
				txtCurrent.Text = "";
				txtExecutable.Text = Program.SyncExePath;
				txtNew.Text = Program.SyncConfigPath;
				switch (Program.SyncPriority)
				{
					case ProcessPriorityClass.RealTime: cmbPriority.SelectedItem = "Real Time"; break;
					case ProcessPriorityClass.High: cmbPriority.SelectedItem = "High"; break;
					case ProcessPriorityClass.AboveNormal: cmbPriority.SelectedItem = "Above Normal"; break;
					case ProcessPriorityClass.Normal: cmbPriority.SelectedItem = "Normal"; break;
					case ProcessPriorityClass.BelowNormal: cmbPriority.SelectedItem = "Below Normal"; break;
					case ProcessPriorityClass.Idle: cmbPriority.SelectedItem = "Idle"; break;
					default: cmbPriority.SelectedItem = "Normal"; break;
				}
				cmbPriority.SelectedItem = Program.SyncPriority.ToString();
				if (Program.IsInstalled)
				{
					btnInstall.Visible = false;
					btnSave.Visible = true;
				}
			}
			else
			{
				string res = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				if (Directory.Exists(Path.Combine(res, "Syncthing")))
					if (File.Exists(Path.Combine(res, "Syncthing", "config.xml")))
						txtCurrent.Text = Path.Combine(res, "Syncthing");
				res = Path.Combine(Application.StartupPath, "syncthing.exe");
				if (File.Exists(res))
					txtExecutable.Text = res;
				else
				{
					res = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "syncthing.exe");
					if (File.Exists(res))
						txtExecutable.Text = res;
					else
					{
						res = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Syncthing", "syncthing.exe");
						if (File.Exists(res))
							txtExecutable.Text = res;
						else
						{
							res = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "syncthing.exe");
							if (File.Exists(res))
								txtExecutable.Text = res;
							else
							{
								res = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Syncthing", "syncthing.exe");
								if (File.Exists(res))
									txtExecutable.Text = res;
							}
						}
					}
				}
				txtNew.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Syncthing", "Data");
				cmbPriority.SelectedItem = "Normal";
			}

			if (Program.AutoRestart)
			{
				chkAutoRestart.Checked = true;
				numMaxAutoCount.Value = Program.AutoRestartCount;
				if (Program.AutoRestartPeriod.Hours > 0)
				{
					numMaxAutoDuration.Value = Program.AutoRestartPeriod.Hours;
					cmbMaxAutoDuration.SelectedItem = "hours";
				}
				else if (Program.AutoRestartPeriod.Minutes > 0)
				{
					numMaxAutoDuration.Value = Program.AutoRestartPeriod.Minutes;
					cmbMaxAutoDuration.SelectedItem = "minutes";
				}
				else if (Program.AutoRestartPeriod.Seconds > 0)
				{
					numMaxAutoDuration.Value = Program.AutoRestartPeriod.Seconds;
					cmbMaxAutoDuration.SelectedItem = "seconds";
				}
				else
				{
					numMaxAutoDuration.Value = 0;
					cmbMaxAutoDuration.SelectedItem = null;
				}
			}
		}

		void CheckInstallEnabled()
		{
			if (!string.IsNullOrWhiteSpace(txtCurrent.Text) && (!Directory.Exists(txtCurrent.Text) || (!File.Exists(Path.Combine(txtCurrent.Text, "config.xml"))))) { btnInstall.Enabled = false; btnSave.Enabled = false; return; }
			if (string.IsNullOrWhiteSpace(txtNew.Text)) { btnInstall.Enabled = false; btnSave.Enabled = false; return; }
			if (string.IsNullOrWhiteSpace(txtExecutable.Text)) { btnInstall.Enabled = false; btnSave.Enabled = false; return; }
			if (string.IsNullOrWhiteSpace(txtCurrent.Text) && (!Directory.Exists(txtNew.Text) || (!File.Exists(Path.Combine(txtNew.Text, "config.xml"))))) { btnInstall.Enabled = false; btnSave.Enabled = false; return; }
			if (!File.Exists(txtExecutable.Text)) { btnInstall.Enabled = false; btnSave.Enabled = false; return; }
			btnInstall.Enabled = true;
			btnSave.Enabled = true;
		}

		private void txtCurrent_TextChanged(object sender, EventArgs e)
		{
			CheckInstallEnabled();
		}

		private void txtNew_TextChanged(object sender, EventArgs e)
		{
			CheckInstallEnabled();
		}

		private void txtExecutable_TextChanged(object sender, EventArgs e)
		{
			CheckInstallEnabled();
		}

		private void btnCurrent_Click(object sender, EventArgs e)
		{
			dlgSelectFolder.ShowNewFolderButton = false;
			dlgSelectFolder.Description = "Select the folder containing the current configuration";
			if (dlgSelectFolder.ShowDialog() == DialogResult.OK)
				txtCurrent.Text = dlgSelectFolder.SelectedPath;
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
			dlgSelectFolder.ShowNewFolderButton = true;
			dlgSelectFolder.Description = "Select the folder where the new configuration should be placed or is already placed";
			if (dlgSelectFolder.ShowDialog() == DialogResult.OK)
				txtNew.Text = dlgSelectFolder.SelectedPath;
		}

		private void btnExecutable_Click(object sender, EventArgs e)
		{
			if (dlgOpenFile.ShowDialog() == DialogResult.OK)
				txtExecutable.Text = dlgOpenFile.SafeFileName;
		}

		private void btnInstall_Click(object sender, EventArgs e)
		{
			// Copy the configuration files, Write the values to the registry, install the service, start the service and set the installed to true!
			if (!string.IsNullOrWhiteSpace(txtCurrent.Text))
				CopyDirectory(txtCurrent.Text, txtNew.Text);

			bool saved = SaveConfig();

			ServiceStartMode StartMode;
			ServiceAccount Account;
			bool DelayedStart;

			switch (cmbAccount.SelectedItem as string)
			{
				case "Local System": Account = ServiceAccount.LocalSystem; break;
				case "Local Service": Account = ServiceAccount.LocalService; break;
				case "Network Service": Account = ServiceAccount.NetworkService; break;
				case "User": Account = ServiceAccount.User; break;
				default: Account = ServiceAccount.LocalSystem; break;
			}
			switch (cmbStartup.SelectedItem as string)
			{
				case "Automatic (Delayed Start)": StartMode = ServiceStartMode.Automatic; DelayedStart = true; break;
				case "Automatic": StartMode = ServiceStartMode.Automatic; DelayedStart = false; break;
				case "Manual": StartMode = ServiceStartMode.Manual; DelayedStart = false; break;
				case "Disabled": StartMode = ServiceStartMode.Disabled; DelayedStart = false; break;
				default: StartMode = ServiceStartMode.Automatic; DelayedStart = false; break;
			}

			Program.InstallService(StartMode, DelayedStart, Account, txtLogin.Text, txtPassword.Text);
			Program.StartService();
			installed = true;
			if(saved) Close();
		}

		void CopyDirectory(string Source, string Destination)
		{
			if (!Directory.Exists(Destination)) Directory.CreateDirectory(Destination);
			foreach (string dir in Directory.EnumerateDirectories(Source))
				CopyDirectory(dir, dir.Replace(Source, Destination));
			foreach (string src in Directory.EnumerateFiles(Source))
			{
				string dst = src.Replace(Source, Destination);
				if (File.Exists(dst)) File.Delete(dst);
				File.Copy(src, dst);
			}
		}

		private void chkAdvanced_CheckedChanged(object sender, EventArgs e)
		{
			this.Height = chkAdvanced.Checked ? 307 : 194;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if(SaveConfig())			Close();
		}

		bool SaveConfig()
		{
			RegistryKey klm = Registry.LocalMachine;
			if (klm == null) return false;
			using (RegistryKey ksoft = klm.CreateSubKey("SOFTWARE"))
			{
				if (ksoft == null) return false;
				using (RegistryKey ksync = ksoft.CreateSubKey("Syncthing Service"))
				{
					if (ksync == null) return false;
					ksync.SetValue("Executable", txtExecutable.Text);
					ksync.SetValue("Configuration", txtNew.Text);
					ksync.SetValue("Priority", string.IsNullOrWhiteSpace(cmbPriority.SelectedItem as string) ? "Normal" : cmbPriority.SelectedItem);
					if (chkAutoRestart.Checked)
					{
						string val = "Yes:";
						if ((numMaxAutoCount.Value == 0) || (numMaxAutoDuration.Value == 0) || (cmbMaxAutoDuration.SelectedItem == null))
							val += "unlimited";
						else
						{
							val += ((int)numMaxAutoCount.Value).ToString()+",";
							switch (cmbMaxAutoDuration.SelectedItem as string)
							{
								case "seconds": val += (new TimeSpan(0, 0, (int)numMaxAutoDuration.Value)).ToString("h\\:m\\:s"); break;
								case "minutes": val += (new TimeSpan(0, (int)numMaxAutoDuration.Value, 0)).ToString("h\\:m\\:s"); break;
								case "hours": val += (new TimeSpan( (int)numMaxAutoDuration.Value,0, 0)).ToString("h\\:m\\:s"); break;
							}
						}
						ksync.SetValue("Autorestart", val);
					}
					else
						ksync.SetValue("Autorestart", "No");
				}
			}
			return true;
		}

		private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
		{
			CheckInstallEnabled();
		}

		private void btnUninstall_Click(object sender, EventArgs e)
		{
			Program.StopService();
			Program.UninstallService();
			installed = true;
			Close();
		}

		private void cmbAccount_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbAccount.SelectedItem as string == "User")
			{
				txtLogin.Enabled = true;
				txtPassword.Enabled = true;
			}
			else
			{
				txtLogin.Enabled = false;
				txtPassword.Enabled = false;
			}
		}

		private void chkAutoRestart_CheckedChanged(object sender, EventArgs e)
		{
			numMaxAutoCount.Enabled = chkAutoRestart.Checked;
			numMaxAutoDuration.Enabled = chkAutoRestart.Checked;
			cmbMaxAutoDuration.Enabled = chkAutoRestart.Checked;
		}
	}
}
