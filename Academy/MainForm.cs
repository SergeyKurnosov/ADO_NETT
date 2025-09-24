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

namespace Academy
{
	public partial class MainForm : Form
	{

		string connecctionString = "Data Source=SERGEY\\MSSQLSERVER17;Initial Catalog=PD_321;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		SqlConnection connection;
		Dictionary<string, int> d_groupsDirection;
		Dictionary<string, int> d_StudentsGroups;
		Dictionary<string, int> d_StudentsDirection;
		public MainForm()
		{
			InitializeComponent();
			connection = new SqlConnection(connecctionString);

			//	LoadDirections();
			//	LoadGroups();
			dataGridViewDirections.DataSource = Select
			(
			"direction_id,direction_name,COUNT(group_id) AS N'Количество групп'", "Groups", "",
			"RIGHT JOIN Directions ON (direction=direction_id) GROUP BY direction_id,direction_name"
			);
			dataGridViewGroups.DataSource = Select
				(
				"group_id,group_name,direction", "Groups,Directions", "direction=direction_id"
				);
			dataGridViewStudents.DataSource = Select
				(
				"stud_id,last_name,first_name, group_name, direction_name ", "Students,Groups,Directions", "[group]=group_id AND direction=direction_id"
				);


			d_groupsDirection = LoadDataToCombobox("*", "Directions");
			d_StudentsGroups = LoadDataToCombobox("*", "Groups");
			d_StudentsDirection = LoadDataToCombobox("*", "Directions");
			comboBoxGroupsDirections.Items.AddRange(d_groupsDirection.Keys.ToArray());
			comboBoxStudentsGroups.Items.AddRange(d_StudentsGroups.Keys.ToArray());
			comboBoxStudentsDirections.Items.AddRange(d_StudentsDirection.Keys.ToArray());

			comboBoxGroupsDirections.SelectedIndex = 0;
			comboBoxStudentsGroups.SelectedIndex = 0;
			comboBoxStudentsDirections.SelectedIndex = 0;

		}

		DataTable Select(string fields, string tables, string conditions = "", string more_conditions = "")
		{
			DataTable table = new DataTable();
			string cmd =
	$@"SELECT {fields} FROM	{tables}";
			if (!string.IsNullOrWhiteSpace(more_conditions))
				cmd += $" {more_conditions}";

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
		void LoadDirections()
		{
			string cmd =
				@"SELECT direction_id AS N'ID' ,direction_name AS N'Направление', COUNT(group_id) AS N'Количество групп'
FROM Groups
RIGHT JOIN Directions ON (direction=direction_id)
GROUP BY direction_id,direction_name;";
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
			dataGridViewDirections.DataSource = table;
		}
		void LoadGroups()
		{
			string cmd =
				@"SELECT group_id AS N'ID' ,group_name AS N'Группа', COUNT(stud_id) AS N'Количество студентов',direction_name AS N'Название'
FROM Students
RIGHT JOIN Groups ON ([group]=group_id)
      JOIN Directions ON (direction=direction_id)
GROUP BY group_id, group_name, direction,direction_name;";
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
			dataGridViewGroups.DataSource = table;
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

		private void comboBoxStudentsGroups_SelectedIndexChanged(object sender, EventArgs e)
		{
			string condition = "[group]=group_id AND direction=direction_id";
			if (comboBoxStudentsGroups.SelectedItem.ToString() != "Все")
				condition += $" AND [group]={d_StudentsGroups[comboBoxStudentsGroups.SelectedItem.ToString()]}";

			dataGridViewStudents.DataSource = Select
				(
				"stud_id,last_name,first_name, group_name, direction_name",
				"Students,Groups,Directions",
				condition
				);
		}

		private void comboBoxStudentsDirections_SelectedIndexChanged(object sender, EventArgs e)
		{
			string condition = "[group]=group_id AND direction=direction_id";
			if (comboBoxStudentsGroups.SelectedItem.ToString() != "Все")
				condition += $" AND [group]={d_StudentsGroups[comboBoxStudentsGroups.SelectedItem.ToString()]}";
			if (comboBoxStudentsDirections.SelectedItem.ToString() != "Все")
				condition += $" AND direction={d_StudentsDirection[comboBoxStudentsDirections.SelectedItem.ToString()]}";


			dataGridViewStudents.DataSource = Select
				(
				"stud_id,last_name,first_name, group_name, direction_name",
				"Students,Groups,Directions",
				condition
				);
		}

		private void checkBoxEmptyDirections_CheckedChanged(object sender, EventArgs e)
		{
			string having = checkBoxEmptyDirections.Checked ? "HAVING COUNT(group_id) = 0" : "";

			dataGridViewDirections.DataSource = Select
(
   "direction_id,direction_name,COUNT(group_id) AS N'Количество групп'", "Groups", "",
$"RIGHT JOIN Directions ON (direction=direction_id) GROUP BY direction_id,direction_name {having}"
);




		}
	}
}
