using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncThingTray
{
	public partial class frmGUI : Form
	{
		public frmGUI()
		{
			InitializeComponent();
		}

		public static void ShowGUI(string URL)
		{
			frmGUI frm = new frmGUI();
			frm.Show();
			frm.webBrowser.Navigate(URL);
		}
	}
}
