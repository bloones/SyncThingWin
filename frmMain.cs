using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SyncThingTray
{
	public partial class frmMain : Form
	{
		bool allowclose = false;
		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			if (!Program.IsInstalled || !Program.IsConfigured)
			{
				if (!frmInstall.TryInstall()) { allowclose = true; Application.Exit(); return; }
			}
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if ((e.CloseReason == CloseReason.UserClosing) && !allowclose)
			{
				e.Cancel = !allowclose;
				Hide();
				return;
			}
		}

		private void showConsoleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Show();
		}

		private void showGuiToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(Program.GuiUrl)) Process.Start(Program.GuiUrl);
		}

		private void stopServiceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.IsUserAdministrator)
				Program.StopService();
			else
				Program.RunAsAdministrator("stop");
		}

		private void startServiceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.IsUserAdministrator)
				Program.StartService();
			else
				Program.RunAsAdministrator("start");
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			allowclose = true;
			Close();
		}

		private void icoTray_DoubleClick(object sender, EventArgs e)
		{
			Show();
		}

		private void timReferesh_Tick(object sender, EventArgs e)
		{
			txtContent.Text = File.Exists(Program.MonitorFile) ? File.ReadAllText(Program.MonitorFile) : string.Empty;
			txtContent.SelectionStart = txtContent.Text.Length;
			txtContent.SelectionLength = 0;
		}

		private void frmMain_VisibleChanged(object sender, EventArgs e)
		{
			if (Visible)
				txtContent.Text = File.Exists(Program.MonitorFile) ? File.ReadAllText(Program.MonitorFile) : string.Empty;
			txtContent.SelectionStart = txtContent.Text.Length;
			txtContent.SelectionLength = 0;
			timReferesh.Enabled = Visible;
		}

		private void mnuTray_Opening(object sender, CancelEventArgs e)
		{
			SetServiceStatus(true);
			Program.ReadConfiguration();
			showGuiToolStripMenuItem.Enabled = !string.IsNullOrWhiteSpace(Program.GuiUrl);
			if (string.IsNullOrWhiteSpace(Program.APIUrl) || string.IsNullOrWhiteSpace(Program.APIKey) || (!Program.IsRunning && !API.IsAvailable))
			{
				mnuRestart.Enabled = false;
				mnuShutdown.Enabled = false;
				mnuUpgrade.Enabled = false;
			}
			else
			{
				mnuRestart.Enabled = true;
				mnuShutdown.Enabled = true;
				mnuUpgrade.Enabled = true;
			}
		}

		private async void mnuShutdown_Click(object sender, EventArgs e)
		{
			var res = await API.CallAPIPost("shutdown");
			if (res != null) icoTray.ShowBalloonTip(1000, "Syncthing", res, ToolTipIcon.Error);
		}

		private async void mnuUpgrade_Click(object sender, EventArgs e)
		{
			var res = await API.CallAPIPost("upgrade");
			if (res != null) icoTray.ShowBalloonTip(1000, "Syncthing", res, ToolTipIcon.Error);
		}

		private async void mnuRestart_Click(object sender, EventArgs e)
		{
			var res = await API.CallAPIPost("restart");
			if (res != null) icoTray.ShowBalloonTip(1000, "Syncthing", res, ToolTipIcon.Error);
		}

		private void frmMain_Shown(object sender, EventArgs e)
		{
			SetServiceStatus(false);
			timStatus.Enabled = true;
		}

		private void timStatus_Tick(object sender, EventArgs e)
		{
			SetServiceStatus(true);
		}

		void SetServiceStatus(bool Update)
		{
			if (Program.IsRunning)
			{
				if (!Update)
					icoTray.ShowBalloonTip(500, "Syncthing", "The service is running", ToolTipIcon.Info);
				else if (startServiceToolStripMenuItem.Enabled)
					icoTray.ShowBalloonTip(500, "Syncthing", "The service has started", ToolTipIcon.Info);
				startServiceToolStripMenuItem.Enabled = false;
				stopServiceToolStripMenuItem.Enabled = true;
			}
			else
			{
				if (!Update)
					icoTray.ShowBalloonTip(500, "Syncthing", "The service is stopped", ToolTipIcon.Error);
				else if (!startServiceToolStripMenuItem.Enabled)
					icoTray.ShowBalloonTip(500, "Syncthing", "The service has stopped", ToolTipIcon.Error);
				startServiceToolStripMenuItem.Enabled = true;
				stopServiceToolStripMenuItem.Enabled = false;
			}
		}
	}
}
