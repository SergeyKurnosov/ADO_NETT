using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;


namespace Academy
{
	public partial class MainForm : Form
	{

		string connecctionString = "Data Source=SERGEY\\MSSQLSERVER17;Initial Catalog=PD_321;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		SqlConnection connection;
		string[] tables_names = { "Students", "Groups", "Directions", "Disciplines", "Teachers" };
		public MainForm()
		{
			InitializeComponent();
			connection = new SqlConnection(connecctionString);
			for (int i = 0; i < tables_names.Length; i++)
				LoadDatas(tables_names[i]);

			GetCountRows();

			//	LoadDirections();

		}

		//void LoadDirections()
		//{
		//	string cmd = "SELECT * FROM Directions";
		//	SqlCommand command = new SqlCommand(cmd, connection);
		//	connection.Open();
		//	SqlDataReader reader = command.ExecuteReader();
		//	DataTable table = new DataTable();
		//	for (int i = 0; i < reader.FieldCount; i++)
		//	{
		//		table.Columns.Add(reader.GetName(i));
		//	}
		//	while (reader.Read())
		//	{
		//		DataRow row = table.NewRow();
		//		for (int i = 0; i < reader.FieldCount; i++)
		//		{
		//			row[i] = reader[i];
		//		}
		//		table.Rows.Add(row);
		//	}
		//	reader.Close();
		//	connection.Close();
		//	dataGridViewDirections.DataSource = table;
		//}


		void LoadDatas(string table_name)
		{
			string cmd = $"SELECT * FROM {table_name}";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			DataTable table = new DataTable();
			for (int i = 0; i < reader.FieldCount; i++)
			{
				table.Columns.Add(reader.GetName(i));
			}
			while (reader.Read())
			{
				DataRow row = table.NewRow();
				for (int i = 0; i < reader.FieldCount; i++)
				{
					row[i] = reader[i];
				}
				table.Rows.Add(row);
			}
			reader.Close();
			connection.Close();
			DataGridView dataGridView;

			switch (table_name)
			{
				case "Students":
					dataGridView = dataGridViewStudents;
					break;
				case "Groups":
					dataGridView = dataGridViewGroups;
					break;
				case "Directions":
					dataGridView = dataGridViewDirections;
					break;
				case "Disciplines":
					dataGridView = dataGridViewDisciplines;
					break;
				case "Teachers":
					dataGridView = dataGridViewTeachers;
					break;
				default:
					dataGridView = null;
					break;
			}
			dataGridView.DataSource = table;

		}


		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			GetCountRows();
		}

		private void GetCountRows()
		{
			int i = tabControl1.SelectedIndex;

			string cmd = $"SELECT COUNT(*) FROM {tables_names[i]}";

			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			int count = 0;

			object res = command.ExecuteScalar();
			if (res != null)
			{
				try
				{
					int.TryParse(res.ToString(), out count);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}


				toolStripStatusLabel1.Text = $"Count Rows {count}";
				connection.Close();
			}
		}


	}
}
