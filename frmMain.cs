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
		string gui;
		string apiurl;
		string apikey;
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
			if (!string.IsNullOrWhiteSpace(gui)) Process.Start(gui);
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
					{
						gui = (tls == "true" ? "https://" : "http://") + xas[0].InnerText;
						apiurl = "http://" + xas[0].InnerText;
					}
					xas = xg.GetElementsByTagName("apikey");
					if (xas.Count == 1)
						apikey = xas[0].InnerText;
				}
			}
			showGuiToolStripMenuItem.Enabled = !string.IsNullOrWhiteSpace(gui);
			if (string.IsNullOrWhiteSpace(apiurl) || string.IsNullOrWhiteSpace(apikey)||  (!Program.IsRunning && !IsAvailable()))
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

		bool IsAvailable()
		{
			var res = CallAPIPost("ping");
			if (!res.Wait(1000)) return false;
			return res.Result == null;
		}

		private async void mnuShutdown_Click(object sender, EventArgs e)
		{
			var res = await CallAPIPost("shutdown");
			if (res != null) icoTray.ShowBalloonTip(1000, "Syncthing", res, ToolTipIcon.Error);
		}

		private async Task<string> CallAPIPost(string Query)
		{
			if (string.IsNullOrWhiteSpace(apiurl)) return "Syncthing address unavailable";
			try
			{
				HttpClient client = new HttpClient();
				client.BaseAddress = new Uri(apiurl);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Add("X-API-Key", apikey);
				HttpContent cnt = new ByteArrayContent(new byte[0]);
				var res = await client.PostAsync("rest/" + Query, cnt);
				return res.IsSuccessStatusCode ? null : "Error: " + res.ToString();
			}
			catch (HttpRequestException x)
			{
				return "Exception: " + x.Message;
			}
		}

		private async void mnuUpgrade_Click(object sender, EventArgs e)
		{
			var res = await CallAPIPost("upgrade");
			if (res != null) icoTray.ShowBalloonTip(1000, "Syncthing", res, ToolTipIcon.Error);
		}

		private async void mnuRestart_Click(object sender, EventArgs e)
		{
			var res = await CallAPIPost("restart");
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
