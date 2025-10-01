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
		Dictionary<string, int> d_groupsDirection;
		Dictionary<string, int> d_disciplineDirection;
		Dictionary<string, int> d_StudentsDirection;
		DTS dts;
		//	System.Data.DataSet GroupsRelatedData = null;
		public MainForm()
		{
			InitializeComponent();
			connectionString = ConfigurationManager.ConnectionStrings["PD_321"].ConnectionString;
			connection = new SqlConnection(connectionString);

			AllocConsole();

			dts = new DTS(connectionString, connection);
			//		dts.Generic_Table("Directions");
			//		dts.Generic_Table("Disciplines");
			//	dts.Generic_Table("Groups"); 
			dts.Generic_Table("Students");
			dts.Generic_Table("DisciplinesDirectionsRelation");


			TabControl tabControl = new TabControl();
			tabControl.Dock = DockStyle.Fill;
			this.Controls.Add(tabControl);

			d_groupsDirection = LoadDataToCombobox(dts.ds.Tables["Directions"]);
			d_disciplineDirection = LoadDataToCombobox(dts.ds.Tables["Directions"]);


			TabPage tabPage = new TabPage();
			for (int i = 0; i < dts.ds.Tables.Count; i++)
			{
				tabPage = new TabPage(dts.ds.Tables[i].TableName);

				DataGridView dataGridView = new DataGridView();
				dataGridView.Name = dts.ds.Tables[i].TableName;
				dataGridView.Top = 50;
				dataGridView.Width = 790;
				dataGridView.Height = 350;
				dataGridView.Anchor = AnchorStyles.Left | AnchorStyles.Top;
				dataGridView.DataSource = dts.ds.Tables[i];
				tabPage.Controls.Add(dataGridView);


				if (dts.ds.Tables[i].TableName == "Groups")
				{
					ComboBox comboBox = new ComboBox();
					comboBox.Name = "Groups";
					comboBox.Location = new Point(10, 10);
					comboBox.Size = new Size(150, 25);
					comboBox.Items.AddRange(d_groupsDirection.Keys.ToArray());
					comboBox.SelectedIndex = 0;
					comboBox.SelectedIndexChanged += DIRECTIONS_SelectedIndexChanged;
					tabPage.Controls.Add(comboBox);
				}

				if (dts.ds.Tables[i].TableName == "Discipline")
				{
					ComboBox comboBox = new ComboBox();
					comboBox.Name = "Discipline";
					comboBox.Location = new Point(10, 10);
					comboBox.Size = new Size(150, 25);
					comboBox.Items.AddRange(d_disciplineDirection.Keys.ToArray());
					comboBox.SelectedIndex = 0;
					comboBox.SelectedIndexChanged += DIRECTIONS_SelectedIndexChanged;
					tabPage.Controls.Add(comboBox);
				}


				tabControl.TabPages.Add(tabPage);
			}




		}




		[DllImport("kernel32.dll")]
		public static extern bool AllocConsole();
		[DllImport("kernel32.dll")]
		public static extern bool FreeConsole();



		Dictionary<string, int> LoadDataToCombobox(DataTable dataTable)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			dictionary.Add("Все", 0);

			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataRow row = dataTable.Rows[i];
				dictionary.Add(row[1].ToString(), Convert.ToInt32(row[0]));
			}
			return dictionary;
		}

		private void DIRECTIONS_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cmb = sender as ComboBox;
			DataTable dataTable = new DataTable();
			DataGridView dataGridView = this.Controls.Find("Groups", true)
				   .FirstOrDefault() as DataGridView;

			if (cmb.SelectedItem.ToString() == "Все")
			{
				dataTable = dts.ds.Tables["Groups"];
				dataGridView.DataSource = dataTable;
			}
				
			if (cmb.SelectedItem.ToString() != "Все")
			{
				DataRow[] dataRows;
				dataRows = dts.ds.Tables["Groups"].Select($"direction = {d_groupsDirection[cmb.SelectedItem.ToString()]}");
				dataTable = dts.ds.Tables["Groups"].Clone();

				foreach (DataRow row in dataRows)
				{
					dataTable.ImportRow(row);
				}
				dataGridView.DataSource = dataTable;
			}
		}

		private void DISCIPLINES_DIRECTIONS_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cmb = sender as ComboBox;
			DataTable dataTable = new DataTable();
			DataGridView dataGridView = this.Controls.Find("Disciplines", true)
				   .FirstOrDefault() as DataGridView;

			if (cmb.SelectedItem.ToString() == "Все")
			{
				dataTable = dts.ds.Tables["Disciplines"];
				dataGridView.DataSource = dataTable;
			}

			if (cmb.SelectedItem.ToString() != "Все")
			{
				DataRow[] dataRows;

				dataRows = dts.ds.Tables["DisciplinesDirectionsRelation"].Select($"direction = {d_groupsDirection[cmb.SelectedItem.ToString()]}");
				dataTable = dts.ds.Tables["DisciplinesDirectionsRelation"].Clone();
				foreach (DataRow row in dataRows)
				{
					dataTable.ImportRow(row);
				}

				DataRow[] dataRows1 = new DataRow[dataTable.Rows.Count]; // = dts.ds.Tables["Disciplines"].Select($"discipline_id = {d_groupsDirection[cmb.SelectedItem.ToString()]}");

				for (int i = 0; i < dataTable.Rows.Count; i++) 
				{
					dataRows1[i];
				}

				foreach (DataRow row in dataTable.Rows)
				{
					dataRows1
				}



				dataGridView.DataSource = dataTable;
			}
		}
	}
}
