using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SyncThingTray
{
	public partial class frmMain : Form
	{
		bool allowclose = false;
		string gui;
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
			startServiceToolStripMenuItem.Enabled = !Program.IsRunning;
			stopServiceToolStripMenuItem.Enabled = Program.IsRunning;
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
			if (!string.IsNullOrWhiteSpace(gui)) frmGUI.ShowGUI(gui);
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
			txtContent.Text =File.Exists(Program.MonitorFile)? File.ReadAllText(Program.MonitorFile):string.Empty;
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
			startServiceToolStripMenuItem.Enabled = !Program.IsRunning;
			stopServiceToolStripMenuItem.Enabled = Program.IsRunning;
			string cfgpath = Path.Combine(Program.SyncConfigPath, "config.xml");
			if (File.Exists(cfgpath))
			{
				XmlDocument xml = new XmlDocument();
				xml.Load(cfgpath);
				XmlElement xr = xml.DocumentElement;
				var xgs = xr.GetElementsByTagName("gui");
				if (xgs.Count == 1)
				{
					XmlElement xg = (XmlElement)xgs[0];
					string tls = xg.GetAttribute("tls");
					var xas = xg.GetElementsByTagName("address");
					if (xas.Count == 1)
						gui = (tls == "true" ? "https://" : "http://") + xas[0].InnerText;
				}
			}
		}
	}
}
