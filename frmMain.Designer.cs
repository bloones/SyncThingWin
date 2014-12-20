namespace SyncThingTray
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.txtContent = new System.Windows.Forms.TextBox();
			this.mnuTray = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.showConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showGuiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.stopServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.icoTray = new System.Windows.Forms.NotifyIcon(this.components);
			this.timReferesh = new System.Windows.Forms.Timer(this.components);
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuShutdown = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuUpgrade = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRestart = new System.Windows.Forms.ToolStripMenuItem();
			this.timStatus = new System.Windows.Forms.Timer(this.components);
			this.mnuTray.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtContent
			// 
			this.txtContent.BackColor = System.Drawing.Color.Black;
			this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtContent.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtContent.ForeColor = System.Drawing.Color.White;
			this.txtContent.Location = new System.Drawing.Point(0, 0);
			this.txtContent.Multiline = true;
			this.txtContent.Name = "txtContent";
			this.txtContent.ReadOnly = true;
			this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtContent.Size = new System.Drawing.Size(621, 544);
			this.txtContent.TabIndex = 0;
			// 
			// mnuTray
			// 
			this.mnuTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showConsoleToolStripMenuItem,
            this.showGuiToolStripMenuItem,
            this.toolStripSeparator3,
            this.mnuRestart,
            this.mnuUpgrade,
            this.mnuShutdown,
            this.toolStripSeparator1,
            this.stopServiceToolStripMenuItem,
            this.startServiceToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
			this.mnuTray.Name = "mnuTray";
			this.mnuTray.Size = new System.Drawing.Size(150, 198);
			this.mnuTray.Opening += new System.ComponentModel.CancelEventHandler(this.mnuTray_Opening);
			// 
			// showConsoleToolStripMenuItem
			// 
			this.showConsoleToolStripMenuItem.Name = "showConsoleToolStripMenuItem";
			this.showConsoleToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.showConsoleToolStripMenuItem.Text = "Show &Console";
			this.showConsoleToolStripMenuItem.Click += new System.EventHandler(this.showConsoleToolStripMenuItem_Click);
			// 
			// showGuiToolStripMenuItem
			// 
			this.showGuiToolStripMenuItem.Name = "showGuiToolStripMenuItem";
			this.showGuiToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.showGuiToolStripMenuItem.Text = "Show &Gui";
			this.showGuiToolStripMenuItem.Click += new System.EventHandler(this.showGuiToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(146, 6);
			// 
			// stopServiceToolStripMenuItem
			// 
			this.stopServiceToolStripMenuItem.Name = "stopServiceToolStripMenuItem";
			this.stopServiceToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.stopServiceToolStripMenuItem.Text = "Sto&p Service";
			this.stopServiceToolStripMenuItem.Click += new System.EventHandler(this.stopServiceToolStripMenuItem_Click);
			// 
			// startServiceToolStripMenuItem
			// 
			this.startServiceToolStripMenuItem.Name = "startServiceToolStripMenuItem";
			this.startServiceToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.startServiceToolStripMenuItem.Text = "S&tart Service";
			this.startServiceToolStripMenuItem.Click += new System.EventHandler(this.startServiceToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(146, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// icoTray
			// 
			this.icoTray.BalloonTipTitle = "SyncThing";
			this.icoTray.ContextMenuStrip = this.mnuTray;
			this.icoTray.Icon = ((System.Drawing.Icon)(resources.GetObject("icoTray.Icon")));
			this.icoTray.Text = "SyncThing";
			this.icoTray.Visible = true;
			this.icoTray.DoubleClick += new System.EventHandler(this.icoTray_DoubleClick);
			// 
			// timReferesh
			// 
			this.timReferesh.Interval = 2000;
			this.timReferesh.Tick += new System.EventHandler(this.timReferesh_Tick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(146, 6);
			// 
			// mnuShutdown
			// 
			this.mnuShutdown.Name = "mnuShutdown";
			this.mnuShutdown.Size = new System.Drawing.Size(149, 22);
			this.mnuShutdown.Text = "Shut&down";
			this.mnuShutdown.Click += new System.EventHandler(this.mnuShutdown_Click);
			// 
			// mnuUpgrade
			// 
			this.mnuUpgrade.Name = "mnuUpgrade";
			this.mnuUpgrade.Size = new System.Drawing.Size(149, 22);
			this.mnuUpgrade.Text = "&Upgrade";
			this.mnuUpgrade.Click += new System.EventHandler(this.mnuUpgrade_Click);
			// 
			// mnuRestart
			// 
			this.mnuRestart.Name = "mnuRestart";
			this.mnuRestart.Size = new System.Drawing.Size(149, 22);
			this.mnuRestart.Text = "&Restart";
			this.mnuRestart.Click += new System.EventHandler(this.mnuRestart_Click);
			// 
			// timStatus
			// 
			this.timStatus.Interval = 200;
			this.timStatus.Tick += new System.EventHandler(this.timStatus_Tick);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(621, 544);
			this.Controls.Add(this.txtContent);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SyncThing";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.Shown += new System.EventHandler(this.frmMain_Shown);
			this.VisibleChanged += new System.EventHandler(this.frmMain_VisibleChanged);
			this.mnuTray.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtContent;
		private System.Windows.Forms.ContextMenuStrip mnuTray;
		private System.Windows.Forms.ToolStripMenuItem showConsoleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showGuiToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem stopServiceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem startServiceToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.NotifyIcon icoTray;
		private System.Windows.Forms.Timer timReferesh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem mnuRestart;
		private System.Windows.Forms.ToolStripMenuItem mnuUpgrade;
		private System.Windows.Forms.ToolStripMenuItem mnuShutdown;
		private System.Windows.Forms.Timer timStatus;
	}
}

