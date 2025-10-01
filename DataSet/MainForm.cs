using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Configuration;

namespace DataSet
{
	public partial class MainForm : Form
	{
		string connectionString = "";
		SqlConnection connection = null;
	//	System.Data.DataSet GroupsRelatedData = null;
		public MainForm()
		{
			InitializeComponent();
			connectionString = ConfigurationManager.ConnectionStrings["PD_321"].ConnectionString;
			connection = new SqlConnection(connectionString);

			AllocConsole();

			DTS dts = new DTS(connectionString, connection);
			dts.Generic_Table("Directions");
			dts.Generic_Table("Groups");

		//	dts.Vivodilka();

			TabControl tabControl = new TabControl();
			tabControl.Dock = DockStyle.Fill;
			this.Controls.Add(tabControl);


			TabPage tabPage = new TabPage();
			for (int i = 0; i < dts.ds.Tables.Count; i++)
			{
				tabPage = new TabPage(dts.ds.Tables[i].TableName);

				DataGridView dataGridView = new DataGridView();
				dataGridView.Top = 50;
				dataGridView.Width = 790;
				dataGridView.Height = 350;
				dataGridView.DataSource = dts.ds.Tables[i];
				tabPage.Controls.Add(dataGridView);

				
				if (dts.ds.Tables[i].TableName == "Groups")
				{
					ComboBox comboBox = new ComboBox();
					comboBox.Location = new Point(10, 10);
					comboBox.Size = new Size(150, 25);
					comboBox.Items.AddRange(new string[] { "Опция 1", "Опция 2", "Опция 3" });
					comboBox.SelectedIndex = 0;
					tabPage.Controls.Add(comboBox);
				}

				tabControl.TabPages.Add(tabPage);
			}

			//for (int i = 0; i < tabControl.TabPages.Count; i++)
			//{
			//	if (tabControl.TabPages[i].Name == "Groups")
			//	{
			//		ComboBox comboBox = new ComboBox();
			//		comboBox.Location = new Point(10, 10);
			//		comboBox.Size = new Size(150, 25);
			//		comboBox.Items.AddRange(new string[] { "Опция 1", "Опция 2", "Опция 3" });
			//		comboBox.SelectedIndex = 0;
			//		tabPage.Controls.Add(comboBox);
			//	}
			//}



		}

		[DllImport("kernel32.dll")]
		public static extern bool AllocConsole();
		[DllImport("kernel32.dll")]
		public static extern bool FreeConsole();


	}

}
