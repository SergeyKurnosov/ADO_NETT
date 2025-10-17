using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy
{
	public partial class Authorization : Form
	{
		public string final_connection_string { get; set; }
		public Authorization()
		{
			InitializeComponent();
		}

		private void buttonInput_Click(object sender, EventArgs e)
		{
			string login = textBoxLogin.Text, password = textBoxPassword.Text;

			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
			{
				MessageBox.Show("Не заполнено поле логина или пароля");
				return;
			}

			EncDecClass encDecClass = new EncDecClass("ConnectionStroke.enc", "ConnectionIV.enc", "ConnectionKey.enc");
			string con = encDecClass.connectionStroke;
			con = con.Replace("user",login);
			con = con.Replace("password",password);
			final_connection_string = con;
			Close();
		}
	}
}
