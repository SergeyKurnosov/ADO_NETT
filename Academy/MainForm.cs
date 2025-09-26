using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Academy
{
	public partial class MainForm : Form
	{

		string connecctionString = "Data Source=SERGEY\\MSSQLSERVER17;Initial Catalog=PD_321;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		SqlConnection connection;
		Dictionary<string, int> d_groupsDirection;

		Query[] queries = new Query[]
			{
				new Query(
					"stud_id,FORMATMESSAGE(N'%s %s %s',last_name,first_name,middle_name) AS N'Студент', group_name AS N'Группа',direction_name AS N'Направление'",
					"Students,Groups,Directions",
					"[group]=group_id AND direction = direction_id"
					),
				new Query
				(
					"group_id,group_name,learning_days,start_time,direction_name",
					"Groups,Directions",
					"direction=direction_id"
				),
				new Query("*","Directions"),
				new Query("*","Disciplines"),
				new Query("*", "Teachers"),
			};


		readonly string[] statusBarMessages = new string[]
		{
			"Количество студентов ",
			"Количество групп ",
			"Количество направлений ",
			"Количество дисциплин ",
			"Количество преподователей "
		};
		public MainForm()
		{
			InitializeComponent();
			AllocConsole();
			connection = new SqlConnection(connecctionString);

			//	LoadDirections();
			//	LoadGroups();
			Console.WriteLine(this.Name);
			Console.WriteLine(tabControl.TabCount);

			d_groupsDirection = LoadDataToCombobox("*", "Directions");
			comboBoxGroupsDirections.Items.AddRange(d_groupsDirection.Keys.ToArray());
			comboBoxGroupsDirections.SelectedIndex = 0;

			tabControl.SelectedIndex = 0;

			for (int i = 0; i < tabControl.TabCount; i++)
			{
				(this.Controls.Find($"dataGridView{tabControl.TabPages[i].Name.Remove(0, "tabPage".Length)}", true)[0] as DataGridView).RowsAdded
					+= new DataGridViewRowsAddedEventHandler(this.dataGridViewChanged);
			}


		}

		void LoadTab(int i)
		{
			string tableName = tabControl.TabPages[i].Name.Remove(0, "tabPage".Length);
			DataGridView dataGridView = this.Controls.Find($"dataGridView{tableName}", true)[0] as DataGridView;
			dataGridView.DataSource = Select(queries[i].Fields, queries[i].Tables, queries[i].Condition);
			//	toolStripStatusLabel.Text = $"{statusBarMessages[i]}: {dataGridView.RowCount-1}";
			if (i == 1) ConvertLearningDays();
		}

		void FillStatusBar(int i)
		{

		}


		DataTable Select(string fields, string tables, string conditions = "")
		{
			DataTable table = new DataTable();
			string cmd =
	$@"SELECT {fields} FROM	{tables}";
			if (!string.IsNullOrWhiteSpace(conditions))
				cmd += $" WHERE {conditions}";
			cmd += ";";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			for (int i = 0; i < reader.FieldCount; i++)
			{
				table.Columns.Add(reader.GetName(i));
			}
			while (reader.Read())
			{
				DataRow row = table.NewRow();
				for (int i = 0; i < reader.FieldCount; i++) row[i] = reader[i];

				table.Rows.Add(row);
			}
			reader.Close();
			connection.Close();

			return table;
		}

		void ConvertLearningDays()
		{
			for (int i = 0; i < dataGridViewGroups.RowCount; i++)
			{

				dataGridViewGroups.Rows[i].Cells["learning_days"].Value=
				 new Week(Convert.ToByte(dataGridViewGroups.Rows[i].Cells["learning_days"].Value));
			}
		}

		Dictionary<string, int> LoadDataToCombobox(string fields, string tables)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			dictionary.Add("Все", 0);
			string cmd = $"SELECT {fields} FROM {tables}";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				//	comboBoxGroupsDirections.Items.Add(reader[1]);
				dictionary.Add(reader[1].ToString(), Convert.ToInt32(reader[0]));
			}
			reader.Close();
			connection.Close();
			return dictionary;
		}

		private void comboBoxGroupsDirections_SelectedIndexChanged(object sender, EventArgs e)
		{
			string condition = "direction=direction_id";
			if (comboBoxGroupsDirections.SelectedItem.ToString() != "Все")
				condition += $" AND direction={d_groupsDirection[comboBoxGroupsDirections.SelectedItem.ToString()]}";
			dataGridViewGroups.DataSource = Select
				(
				"group_id,group_name,direction",
				"Groups,Directions",
				condition
				);
		}
		[DllImport("kernel32.dll")]
		static extern void AllocConsole();

		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadTab((sender as TabControl).SelectedIndex);
		}
		private void dataGridViewChanged(object sender, EventArgs e)
		{
			toolStripStatusLabel.Text = $"{statusBarMessages[tabControl.SelectedIndex]}: {(sender as DataGridView).RowCount - 1}";
		}


	}

}
