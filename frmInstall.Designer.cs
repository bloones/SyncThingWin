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
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(132, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "Current Configuration:";
			// 
			// btnCurrent
			// 
			this.btnCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCurrent.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCurrent.Location = new System.Drawing.Point(625, 12);
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
			this.txtCurrent.Location = new System.Drawing.Point(150, 12);
			this.txtCurrent.Name = "txtCurrent";
			this.txtCurrent.Size = new System.Drawing.Size(469, 23);
			this.txtCurrent.TabIndex = 0;
			this.txtCurrent.TextChanged += new System.EventHandler(this.txtCurrent_TextChanged);
			// 
			// btnNew
			// 
			this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNew.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNew.Location = new System.Drawing.Point(625, 41);
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
			this.txtNew.Location = new System.Drawing.Point(150, 41);
			this.txtNew.Name = "txtNew";
			this.txtNew.Size = new System.Drawing.Size(469, 23);
			this.txtNew.TabIndex = 2;
			this.txtNew.TextChanged += new System.EventHandler(this.txtNew_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(113, 14);
			this.label2.TabIndex = 0;
			this.label2.Text = "New Configuration:";
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
			this.btnExecutable.Location = new System.Drawing.Point(625, 70);
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
			this.txtExecutable.Location = new System.Drawing.Point(150, 70);
			this.txtExecutable.Name = "txtExecutable";
			this.txtExecutable.Size = new System.Drawing.Size(469, 23);
			this.txtExecutable.TabIndex = 4;
			this.txtExecutable.TextChanged += new System.EventHandler(this.txtExecutable_TextChanged);
			// 
			// btnInstall
			// 
			this.btnInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnInstall.Enabled = false;
			this.btnInstall.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnInstall.Location = new System.Drawing.Point(500, 99);
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
			// frmInstall
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(661, 128);
			this.Controls.Add(this.txtExecutable);
			this.Controls.Add(this.txtNew);
			this.Controls.Add(this.txtCurrent);
			this.Controls.Add(this.btnInstall);
			this.Controls.Add(this.btnExecutable);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnCurrent);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmInstall";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Syncthing Configuration";
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
	}
}