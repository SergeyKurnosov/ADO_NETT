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
		public MainForm()
		{
			InitializeComponent();
			connection = new SqlConnection(connecctionString);

			//	LoadDirections();
			//	LoadGroups();
			dataGridViewDirections.DataSource = Select("*", "Directions");
			dataGridViewGroups.DataSource = Select
				(
				"group_id,group_name,direction", "Groups,Directions", "direction=direction_id"
				);


			d_groupsDirection = LoadDataToCombobox("*", "Directions");
			comboBoxGroupsDirections.Items.AddRange(d_groupsDirection.Keys.ToArray());
			comboBoxGroupsDirections.SelectedIndex = 0;

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
			for(int i = 0; i < reader.FieldCount; i++)
			{
				table.Columns.Add(reader.GetName(i));
			}
			while (reader.Read())
			{
				DataRow row = table.NewRow();
				for(int i = 0; i < reader.FieldCount; i++) row[i] = reader[i];

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
				@"SELECT group_id AS N'ID' ,direction_name AS N'Группа', COUNT(stud_id) AS N'Количество студентов',direction_name AS N'Название'
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

		Dictionary<string,int> LoadDataToCombobox(string fields, string tables)
		{
			Dictionary<string,int> dictionary = new Dictionary<string,int>();
			dictionary.Add("Все", 0);
			string cmd = $"SELECT {fields} FROM {tables}";
			SqlCommand command = new SqlCommand (cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader ();
			while (reader.Read())
			{
				//	comboBoxGroupsDirections.Items.Add(reader[1]);
				dictionary.Add(reader[1].ToString(), Convert.ToInt32( reader[0]));
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
	}
}
