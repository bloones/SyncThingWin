using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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

			string res = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			if (Directory.Exists(Path.Combine(res, "Syncthing")))
				if (File.Exists(Path.Combine(res, "Syncthing", "config.xml")))
					frm.txtCurrent.Text = Path.Combine(res, "Syncthing");
			res=Path.Combine(Application.StartupPath,"syncthing.exe");
			if (File.Exists(res))
				frm.txtExecutable.Text = res;
			else
			{
				res = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "syncthing.exe");
				if (File.Exists(res))
					frm.txtExecutable.Text = res;
				else
				{
					res = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),"Syncthing", "syncthing.exe");
					if (File.Exists(res))
						frm.txtExecutable.Text = res;
					else
					{
						res = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "syncthing.exe");
						if (File.Exists(res))
							frm.txtExecutable.Text = res;
						else
						{
							res = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Syncthing", "syncthing.exe");
							if (File.Exists(res))
								frm.txtExecutable.Text = res;
						}
					}
				}
			}

			frm.txtNew.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Syncthing", "Data");

			frm.ShowDialog();
			return frm.installed;
		}

		void CheckInstallEnabled()
		{
			if (!string.IsNullOrWhiteSpace(txtCurrent.Text) && (!Directory.Exists(txtCurrent.Text) || (!File.Exists(Path.Combine(txtCurrent.Text, "config.xml"))))) { btnInstall.Enabled = false; return; }
			if (string.IsNullOrWhiteSpace(txtNew.Text)) { btnInstall.Enabled = false; return; }
			if (string.IsNullOrWhiteSpace(txtExecutable.Text)) { btnInstall.Enabled = false; return; }
			if (string.IsNullOrWhiteSpace(txtCurrent.Text) && (!Directory.Exists(txtNew.Text) || (!File.Exists(Path.Combine(txtNew.Text, "config.xml"))))) { btnInstall.Enabled = false; return; }
			if (!File.Exists(txtExecutable.Text)) { btnInstall.Enabled = false; return; }
			btnInstall.Enabled = true;
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
			dlgSelectFolder.Description = "Select the folder containig the current configuration";
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

			RegistryKey klm = Registry.LocalMachine;
			using (RegistryKey ksoft = klm.CreateSubKey("SOFTWARE"))
			using (RegistryKey ksync = ksoft.CreateSubKey("Syncthing Service"))
				{
					ksync.SetValue("Executable", txtExecutable.Text);
					ksync.SetValue("Configuration", txtNew.Text);
				}

			Program.InstallService();
			Program.StartService();
			installed = true;
			Close();
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
	}
}
