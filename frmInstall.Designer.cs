namespace SyncThingTray
{
	partial class frmInstall
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInstall));
			this.label1 = new System.Windows.Forms.Label();
			this.btnCurrent = new System.Windows.Forms.Button();
			this.txtCurrent = new System.Windows.Forms.TextBox();
			this.btnNew = new System.Windows.Forms.Button();
			this.txtNew = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnExecutable = new System.Windows.Forms.Button();
			this.txtExecutable = new System.Windows.Forms.TextBox();
			this.btnInstall = new System.Windows.Forms.Button();
			this.dlgSelectFolder = new System.Windows.Forms.FolderBrowserDialog();
			this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
			this.label4 = new System.Windows.Forms.Label();
			this.imlHelp = new System.Windows.Forms.ImageList(this.components);
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.btnUninstall = new System.Windows.Forms.Button();
			this.chkAdvanced = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbStartup = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.cmbAccount = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.cmbPriority = new System.Windows.Forms.ComboBox();
			this.txtLogin = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.tipHelp = new System.Windows.Forms.ToolTip(this.components);
			this.chkAutoRestart = new System.Windows.Forms.CheckBox();
			this.label12 = new System.Windows.Forms.Label();
			this.numMaxAutoDuration = new System.Windows.Forms.NumericUpDown();
			this.cmbMaxAutoDuration = new System.Windows.Forms.ComboBox();
			this.label15 = new System.Windows.Forms.Label();
			this.numMaxAutoCount = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.numMaxAutoDuration)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxAutoCount)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(133, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "Existing Configuration:";
			// 
			// btnCurrent
			// 
			this.btnCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCurrent.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCurrent.Location = new System.Drawing.Point(599, 12);
			this.btnCurrent.Name = "btnCurrent";
			this.btnCurrent.Size = new System.Drawing.Size(24, 23);
			this.btnCurrent.TabIndex = 1;
			this.btnCurrent.Text = "...";
			this.btnCurrent.UseVisualStyleBackColor = true;
			this.btnCurrent.Click += new System.EventHandler(this.btnCurrent_Click);
			// 
			// txtCurrent
			// 
			this.txtCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCurrent.Location = new System.Drawing.Point(181, 12);
			this.txtCurrent.Name = "txtCurrent";
			this.txtCurrent.Size = new System.Drawing.Size(412, 23);
			this.txtCurrent.TabIndex = 0;
			this.txtCurrent.TextChanged += new System.EventHandler(this.txtCurrent_TextChanged);
			// 
			// btnNew
			// 
			this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNew.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNew.Location = new System.Drawing.Point(599, 41);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(24, 23);
			this.btnNew.TabIndex = 3;
			this.btnNew.Text = "...";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// txtNew
			// 
			this.txtNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNew.Location = new System.Drawing.Point(181, 41);
			this.txtNew.Name = "txtNew";
			this.txtNew.Size = new System.Drawing.Size(412, 23);
			this.txtNew.TabIndex = 2;
			this.txtNew.TextChanged += new System.EventHandler(this.txtNew_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 14);
			this.label2.TabIndex = 0;
			this.label2.Text = "Configuration:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 74);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(125, 14);
			this.label3.TabIndex = 0;
			this.label3.Text = "Syncthing Executable:";
			// 
			// btnExecutable
			// 
			this.btnExecutable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExecutable.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnExecutable.Location = new System.Drawing.Point(599, 70);
			this.btnExecutable.Name = "btnExecutable";
			this.btnExecutable.Size = new System.Drawing.Size(24, 23);
			this.btnExecutable.TabIndex = 5;
			this.btnExecutable.Text = "...";
			this.btnExecutable.UseVisualStyleBackColor = true;
			this.btnExecutable.Click += new System.EventHandler(this.btnExecutable_Click);
			// 
			// txtExecutable
			// 
			this.txtExecutable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtExecutable.Location = new System.Drawing.Point(181, 70);
			this.txtExecutable.Name = "txtExecutable";
			this.txtExecutable.Size = new System.Drawing.Size(412, 23);
			this.txtExecutable.TabIndex = 4;
			this.txtExecutable.TextChanged += new System.EventHandler(this.txtExecutable_TextChanged);
			// 
			// btnInstall
			// 
			this.btnInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnInstall.Enabled = false;
			this.btnInstall.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnInstall.Location = new System.Drawing.Point(474, 99);
			this.btnInstall.Name = "btnInstall";
			this.btnInstall.Size = new System.Drawing.Size(149, 23);
			this.btnInstall.TabIndex = 8;
			this.btnInstall.Text = "Save and Install Service";
			this.btnInstall.UseVisualStyleBackColor = true;
			this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
			// 
			// dlgOpenFile
			// 
			this.dlgOpenFile.DefaultExt = "exe";
			this.dlgOpenFile.FileName = "syncthing.exe";
			this.dlgOpenFile.Filter = "Executable|*.exe";
			this.dlgOpenFile.Title = "Select the syncthing executable";
			// 
			// label4
			// 
			this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
			this.label4.Location = new System.Drawing.Point(151, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(24, 23);
			this.label4.TabIndex = 9;
			this.tipHelp.SetToolTip(this.label4, "Path to directory where the current configuration used by syncthing is located. F" +
        "ill this information ONLY if you plan to move your configuration");
			// 
			// imlHelp
			// 
			this.imlHelp.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imlHelp.ImageSize = new System.Drawing.Size(23, 23);
			this.imlHelp.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// label6
			// 
			this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
			this.label6.Location = new System.Drawing.Point(151, 70);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(24, 23);
			this.label6.TabIndex = 9;
			this.tipHelp.SetToolTip(this.label6, "Path to the syncthing executable");
			// 
			// label7
			// 
			this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
			this.label7.Location = new System.Drawing.Point(151, 41);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(24, 23);
			this.label7.TabIndex = 9;
			this.tipHelp.SetToolTip(this.label7, "Path to the directory where the syncthing configuration will be copied to or wher" +
        "e the syncthing configuration already exist");
			// 
			// btnUninstall
			// 
			this.btnUninstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUninstall.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUninstall.Location = new System.Drawing.Point(543, 159);
			this.btnUninstall.Name = "btnUninstall";
			this.btnUninstall.Size = new System.Drawing.Size(80, 23);
			this.btnUninstall.TabIndex = 8;
			this.btnUninstall.Text = "Uninstall";
			this.btnUninstall.UseVisualStyleBackColor = true;
			this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
			// 
			// chkAdvanced
			// 
			this.chkAdvanced.Appearance = System.Windows.Forms.Appearance.Button;
			this.chkAdvanced.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
			this.chkAdvanced.Location = new System.Drawing.Point(354, 99);
			this.chkAdvanced.Name = "chkAdvanced";
			this.chkAdvanced.Size = new System.Drawing.Size(114, 23);
			this.chkAdvanced.TabIndex = 10;
			this.chkAdvanced.Text = "Advanced Options";
			this.chkAdvanced.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.chkAdvanced.UseVisualStyleBackColor = true;
			this.chkAdvanced.CheckedChanged += new System.EventHandler(this.chkAdvanced_CheckedChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(12, 163);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(93, 14);
			this.label5.TabIndex = 0;
			this.label5.Text = "Service Startup:";
			// 
			// cmbStartup
			// 
			this.cmbStartup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStartup.FormattingEnabled = true;
			this.cmbStartup.Items.AddRange(new object[] {
            "Automatic (Delayed Start)",
            "Automatic",
            "Manual",
            "Disabled"});
			this.cmbStartup.Location = new System.Drawing.Point(128, 159);
			this.cmbStartup.Name = "cmbStartup";
			this.cmbStartup.Size = new System.Drawing.Size(190, 23);
			this.cmbStartup.TabIndex = 11;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(12, 192);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(98, 14);
			this.label8.TabIndex = 0;
			this.label8.Text = "Service Account:";
			// 
			// cmbAccount
			// 
			this.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAccount.FormattingEnabled = true;
			this.cmbAccount.Items.AddRange(new object[] {
            "Local System",
            "Local Service",
            "Network Service",
            "User"});
			this.cmbAccount.Location = new System.Drawing.Point(128, 188);
			this.cmbAccount.Name = "cmbAccount";
			this.cmbAccount.Size = new System.Drawing.Size(190, 23);
			this.cmbAccount.TabIndex = 11;
			this.cmbAccount.SelectedIndexChanged += new System.EventHandler(this.cmbAccount_SelectedIndexChanged);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(324, 192);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(41, 14);
			this.label9.TabIndex = 0;
			this.label9.Text = "Login:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(324, 221);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(65, 14);
			this.label10.TabIndex = 0;
			this.label10.Text = "Password:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(12, 243);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(110, 14);
			this.label11.TabIndex = 0;
			this.label11.Text = "Syncthing Priority:";
			// 
			// cmbPriority
			// 
			this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPriority.FormattingEnabled = true;
			this.cmbPriority.Items.AddRange(new object[] {
            "Real Time",
            "High",
            "Above Normal",
            "Normal",
            "Below Normal",
            "Idle"});
			this.cmbPriority.Location = new System.Drawing.Point(128, 239);
			this.cmbPriority.Name = "cmbPriority";
			this.cmbPriority.Size = new System.Drawing.Size(190, 23);
			this.cmbPriority.TabIndex = 11;
			this.cmbPriority.SelectedIndexChanged += new System.EventHandler(this.cmbPriority_SelectedIndexChanged);
			// 
			// txtLogin
			// 
			this.txtLogin.Enabled = false;
			this.txtLogin.Location = new System.Drawing.Point(395, 188);
			this.txtLogin.Name = "txtLogin";
			this.txtLogin.Size = new System.Drawing.Size(228, 23);
			this.txtLogin.TabIndex = 2;
			this.txtLogin.TextChanged += new System.EventHandler(this.txtNew_TextChanged);
			// 
			// txtPassword
			// 
			this.txtPassword.Enabled = false;
			this.txtPassword.Location = new System.Drawing.Point(395, 217);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(228, 23);
			this.txtPassword.TabIndex = 2;
			this.txtPassword.TextChanged += new System.EventHandler(this.txtNew_TextChanged);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Enabled = false;
			this.btnSave.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(474, 99);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(149, 23);
			this.btnSave.TabIndex = 8;
			this.btnSave.Text = "Save Configuration";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Visible = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// tipHelp
			// 
			this.tipHelp.AutomaticDelay = 0;
			this.tipHelp.AutoPopDelay = 0;
			this.tipHelp.InitialDelay = 25;
			this.tipHelp.IsBalloon = true;
			this.tipHelp.ReshowDelay = 0;
			this.tipHelp.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			// 
			// chkAutoRestart
			// 
			this.chkAutoRestart.AutoSize = true;
			this.chkAutoRestart.Location = new System.Drawing.Point(16, 101);
			this.chkAutoRestart.Name = "chkAutoRestart";
			this.chkAutoRestart.Size = new System.Drawing.Size(147, 19);
			this.chkAutoRestart.TabIndex = 12;
			this.chkAutoRestart.Text = "Auto restart syncthing";
			this.chkAutoRestart.UseVisualStyleBackColor = true;
			this.chkAutoRestart.CheckedChanged += new System.EventHandler(this.chkAutoRestart_CheckedChanged);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(238, 130);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(175, 15);
			this.label12.TabIndex = 16;
			this.label12.Text = "shutdown occur in a period of ";
			// 
			// numMaxAutoDuration
			// 
			this.numMaxAutoDuration.Enabled = false;
			this.numMaxAutoDuration.Location = new System.Drawing.Point(419, 127);
			this.numMaxAutoDuration.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
			this.numMaxAutoDuration.Name = "numMaxAutoDuration";
			this.numMaxAutoDuration.Size = new System.Drawing.Size(45, 23);
			this.numMaxAutoDuration.TabIndex = 14;
			// 
			// cmbMaxAutoDuration
			// 
			this.cmbMaxAutoDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMaxAutoDuration.Enabled = false;
			this.cmbMaxAutoDuration.FormattingEnabled = true;
			this.cmbMaxAutoDuration.Items.AddRange(new object[] {
            "seconds",
            "minutes",
            "hours"});
			this.cmbMaxAutoDuration.Location = new System.Drawing.Point(470, 127);
			this.cmbMaxAutoDuration.Name = "cmbMaxAutoDuration";
			this.cmbMaxAutoDuration.Size = new System.Drawing.Size(86, 23);
			this.cmbMaxAutoDuration.TabIndex = 15;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(13, 129);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(166, 15);
			this.label15.TabIndex = 16;
			this.label15.Text = "Stop the service if more than ";
			// 
			// numMaxAutoCount
			// 
			this.numMaxAutoCount.Enabled = false;
			this.numMaxAutoCount.Location = new System.Drawing.Point(185, 127);
			this.numMaxAutoCount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.numMaxAutoCount.Name = "numMaxAutoCount";
			this.numMaxAutoCount.Size = new System.Drawing.Size(47, 23);
			this.numMaxAutoCount.TabIndex = 13;
			// 
			// frmInstall
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(635, 155);
			this.Controls.Add(this.cmbMaxAutoDuration);
			this.Controls.Add(this.numMaxAutoDuration);
			this.Controls.Add(this.chkAutoRestart);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.cmbPriority);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.numMaxAutoCount);
			this.Controls.Add(this.cmbAccount);
			this.Controls.Add(this.cmbStartup);
			this.Controls.Add(this.chkAdvanced);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtExecutable);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtLogin);
			this.Controls.Add(this.txtNew);
			this.Controls.Add(this.txtCurrent);
			this.Controls.Add(this.btnUninstall);
			this.Controls.Add(this.btnInstall);
			this.Controls.Add(this.btnExecutable);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnCurrent);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSave);
			this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmInstall";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Syncthing Service Configuration";
			((System.ComponentModel.ISupportInitialize)(this.numMaxAutoDuration)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxAutoCount)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCurrent;
		private System.Windows.Forms.TextBox txtCurrent;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.TextBox txtNew;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnExecutable;
		private System.Windows.Forms.TextBox txtExecutable;
		private System.Windows.Forms.Button btnInstall;
		private System.Windows.Forms.FolderBrowserDialog dlgSelectFolder;
		private System.Windows.Forms.OpenFileDialog dlgOpenFile;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ImageList imlHelp;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnUninstall;
		private System.Windows.Forms.CheckBox chkAdvanced;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cmbStartup;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cmbAccount;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox cmbPriority;
		private System.Windows.Forms.TextBox txtLogin;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.ToolTip tipHelp;
		private System.Windows.Forms.CheckBox chkAutoRestart;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.NumericUpDown numMaxAutoDuration;
		private System.Windows.Forms.ComboBox cmbMaxAutoDuration;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.NumericUpDown numMaxAutoCount;
	}
}