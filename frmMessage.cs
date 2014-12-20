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
	public partial class frmMessage : Form
	{
		public frmMessage()
		{
			InitializeComponent();
		}

		public frmMessage(string Message)
			: this()
		{
			lblMessage.Text = Message;
		}
	}
}
