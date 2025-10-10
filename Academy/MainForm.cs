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
using System.Configuration;

namespace Academy
{
	public partial class MainForm : Form
	{
		string connecctionString = "Data Source=SERGEY\\MSSQLSERVER17;Initial Catalog=PD_321;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		SqlConnection connection;
		Connector connector;
		Dictionary<string, int> d_groupDirection;
		Dictionary<string, int> d_studentsGroup;

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
			connecctionString = ConfigurationManager.ConnectionStrings["PD_321"].ConnectionString;
			Console.WriteLine(connecctionString);
			connection = new SqlConnection(connecctionString);
			connector = new Connector();
			//	LoadDirections();
			//	LoadGroups();
			Console.WriteLine(this.Name);
			Console.WriteLine(tabControl.TabCount);
		
			d_groupDirection = LoadDataToDictionary("*", "Directions");
			d_studentsGroup = LoadDataToDictionary("*", "Groups");
			comboBoxGroupsDirection.Items.AddRange(d_groupDirection.Keys.ToArray());
			comboBoxStudentsDirection.Items.AddRange(d_groupDirection.Keys.ToArray());
			comboBoxStudentsGroup.Items.AddRange(d_studentsGroup.Keys.ToArray());
			comboBoxStudentsDirection.SelectedIndex = comboBoxGroupsDirection.SelectedIndex = 0;
			comboBoxStudentsGroup.SelectedIndex = 0;

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
			dataGridView.DataSource = connector.Select(queries[i].Fields, queries[i].Tables, queries[i].Condition);
			//	toolStripStatusLabel.Text = $"{statusBarMessages[i]}: {dataGridView.RowCount-1}";
			if (i == 1) ConvertLearningDays();
			dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView.ReadOnly = true;
		}

		void FillStatusBar(int i)
		{

		}


	//	DataTable Select(string fields, string tables, string conditions = "")
	//	{
	//		DataTable table = new DataTable();
	//		string cmd =
	//$@"SELECT {fields} FROM	{tables}";
	//		if (!string.IsNullOrWhiteSpace(conditions))
	//			cmd += $" WHERE {conditions}";
	//		cmd += ";";
	//		SqlCommand command = new SqlCommand(cmd, connection);
	//		connection.Open();
	//		SqlDataReader reader = command.ExecuteReader();
	//		for (int i = 0; i < reader.FieldCount; i++)
	//		{
	//			table.Columns.Add(reader.GetName(i));
	//		}
	//		while (reader.Read())
	//		{
	//			DataRow row = table.NewRow();
	//			for (int i = 0; i < reader.FieldCount; i++) row[i] = reader[i];

	//			table.Rows.Add(row);
	//		}
	//		reader.Close();
	//		connection.Close();

	//		return table;
	//	}

		void Insert(string table, string fields, string values)
		{
			string cmd = $"INSERT {table}({fields}) VALUES ({values})";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}

		void ConvertLearningDays()
		{
			for (int i = 0; i < dataGridViewGroups.RowCount; i++)
			{

				dataGridViewGroups.Rows[i].Cells["learning_days"].Value =
				 new Week(Convert.ToByte(dataGridViewGroups.Rows[i].Cells["learning_days"].Value));
			}
		}

		Dictionary<string, int> LoadDataToDictionary(string fields, string tables, string condition = "")
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			dictionary.Add("Все", 0);
			string cmd = $"SELECT {fields} FROM {tables}";
			if (!string.IsNullOrWhiteSpace(condition))
				cmd += $" WHERE {condition}";

			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				//comboBoxGroupsDirection.Items.Add(reader[1]);
				dictionary.Add(reader[1].ToString(), Convert.ToInt32(reader[0]));
			}
			reader.Close();
			connection.Close();
			return dictionary;
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
			if (comboBoxGroupsDirection.SelectedItem.ToString() != "Все")
				condition += $" AND direction={d_groupDirection[comboBoxGroupsDirection.SelectedItem.ToString()]}";
			dataGridViewGroups.DataSource = connector.Select
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

		private void comboBoxStudentsDirection_SelectedIndexChanged(object sender, EventArgs e)
		{
			string condition = comboBoxStudentsDirection.SelectedItem.ToString() == "Все" ? "" :
				$" direction={d_groupDirection[(sender as ComboBox).SelectedItem.ToString()]}";
			comboBoxStudentsGroup.Items.Clear();
			comboBoxStudentsGroup.Items.AddRange(LoadDataToDictionary("*", "Groups", condition).Keys.ToArray());
			dataGridViewStudents.DataSource = connector.Select
				(
					queries[0].Fields,
					queries[0].Tables,
					queries[0].Condition + (string.IsNullOrEmpty(condition) ? "" : $" AND {condition}")
				);
		}

		private void comboBoxStudentsGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			string condition_group =
				comboBoxStudentsGroup.SelectedItem.ToString() == "Все" ? "" :
				$"[group]={d_studentsGroup[comboBoxStudentsGroup.SelectedItem.ToString()]}";
			string condition_direction = comboBoxStudentsDirection.SelectedItem.ToString() == "Все" ? "" :
				$" direction={d_groupDirection[comboBoxStudentsDirection.SelectedItem.ToString()]}";
			dataGridViewStudents.DataSource = connector.Select
				(
					queries[0].Fields,
					queries[0].Tables,
					queries[0].Condition
					+ (string.IsNullOrWhiteSpace(condition_group) ? "" : $" AND {condition_group}")
					+ (string.IsNullOrWhiteSpace(condition_direction) ? "" : $" AND {condition_direction}")
				);
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			StudentForm student = new StudentForm();
			DialogResult result = student.ShowDialog();
			if (result == DialogResult.OK)
			{

				//todo:делаем insert в базу:
				connector.Insert
					(
					"Students",
					"last_name,first_name,middle_name,birth_date,email,phone,[group]",
					student.Student.ToString()
					);

				int i = Convert.ToInt32(connector.Scalar("SELECT MAX(stud_id) FROM Students"));
				connector.UploadPhoto(student.Student.SerializePhoto(), i, "photo", "Students");

			}


		}                                     

		private void dataGridViewStudents_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int i = Convert.ToInt32(dataGridViewStudents.SelectedRows[0].Cells[0].Value);
			StudentForm student = new StudentForm(i);
			DialogResult result = student.ShowDialog();
			if (result == DialogResult.OK)
			{
				connector.Update
					(
					"Students",
					student.Student.ToStringUpdate(),
					$"stud_id={i}"
					);
				connector.UploadPhoto(student.Student.SerializePhoto(), i, "photo", "Students");
				comboBoxStudentsGroup_SelectedIndexChanged(null, null);

			}



		}

		private void buttonAddTeacher_Click(object sender, EventArgs e)
		{
			TeacherForm teacher = new TeacherForm();
			DialogResult result = teacher.ShowDialog();
			if (result == DialogResult.OK)
			{
				connector.Insert
					(
					"Teachers",
					"teacher_id,last_name,first_name,middle_name,birth_date,email,phone,work_since,rate",
					 $"{Convert.ToInt32(connector.Scalar("SELECT MAX(teacher_id) FROM Teachers"))+1},{teacher.Teacher.ToString()}" 
					);

				int i = Convert.ToInt32(connector.Scalar("SELECT MAX(teacher_id) FROM Teachers"));
				connector.UploadPhoto(teacher.Teacher.SerializePhoto(), i, "photo", "Teachers");

			}
		}

		private void dataGridViewTeachers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			int i = Convert.ToInt32(dataGridViewTeachers.SelectedRows[0].Cells[0].Value);
			TeacherForm teacher = new TeacherForm(i);
			DialogResult result = teacher.ShowDialog();
			if (result == DialogResult.OK)
			{
				connector.Update
					(
					"Teachers",
					teacher.Teacher.ToStringUpdate(),
					$"teacher_id={i}"
					);
				connector.UploadPhoto(teacher.Teacher.SerializePhoto(), i, "photo", "Teachers");

			}
		}
	}

}
