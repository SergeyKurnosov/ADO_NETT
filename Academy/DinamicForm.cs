using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class DinamicForm
	{

		public string table_name { get; set; }                                  //имя таблицы с которой мы работаем
		public List<string> columns_names { get; set; } = new List<string>();   //имена ВСЕХ колонок в таблице
		public List<string> columns_types { get; set; } = new List<string>();   //типы ВСЕХ колонок в таблице
		public List<string> values { get; set; } = new List<string>();          //ВСЕ значения полученные из формы (нулевые и ненулевые)
		public string not_null_fields_for_insert { get; set; }                  //поля с ненулевыми значениями для заполнения
		public string not_null_values_for_insert { get; set; }                  //ненулевые значениями для заполнения
		public List<string> column_names_NOT_NULL { get; set; }                 //поля не нулевые (ОБЯЗАТЕЛЬНЫЕ ДЛЯ ЗАПОЛНЕНИЯ)


		SqlConnection connection { get; set; }
		public Form myForm;
		public Button button;

		public DinamicForm(string table_name, SqlConnection connection)
		{
			this.table_name = table_name;
			this.connection = connection;
			GetNamesFields(connection);

			for (int i = 0; i < columns_names.Count; i++)
			{
				values.Add("");
			}


			myForm = new Form();
			myForm.Text = "Введите данные";
			myForm.Width = 400;
			myForm.Height = 300;

			button = new Button();
			button.Text = "Добавить";
			button.Left = 300;
			button.Top = 10;
			button.Width = 100;
			button.Height = 20;

			button.Click += (sender, e) =>
			{
				not_null_fields_for_insert = String.Empty;
				not_null_values_for_insert = String.Empty;
				preparation_str_for_query();
				Console.WriteLine($"строка для полей - {not_null_fields_for_insert}");
				Console.WriteLine();
				Console.WriteLine($"строка для значений - {not_null_values_for_insert}");

				if (ready_to_Insert())
				{
					Console.WriteLine("Все в порядке");
					Insert(table_name, not_null_fields_for_insert, not_null_values_for_insert);
				}
				else
				{
					Console.WriteLine("Чего то не хватает");
					MessageBox.Show("Не все обязательные данные были добавлены");
				}
					

				//	Console.WriteLine($"INSERT ({table_name}) ({not_null_fields_for_insert}) VALUES ({not_null_values_for_insert});");

			};

			myForm.Controls.Add(button);

			GenericInputFields();

			column_names_NOT_NULL = Get_Not_Null_fields(connection);
			Console.WriteLine("обязательные поля :");
			for (int i = 0; i < column_names_NOT_NULL.Count; i++)
				Console.WriteLine(column_names_NOT_NULL[i]);

		}

		bool ready_to_Insert()
		{
			for (int i = 0; i < columns_names.Count; i++)
			{
				for (int j = 0; j < column_names_NOT_NULL.Count; j++)
				{
					if (columns_names[i].Equals(column_names_NOT_NULL[j]) && String.IsNullOrEmpty(values[i]))
						return false;
				}
			}
			return true;
		}

		List<string> Get_Not_Null_fields(SqlConnection connection)
		{
			List<string> notNullColumns = new List<string>();

			string query = @"
            SELECT COLUMN_NAME
            FROM INFORMATION_SCHEMA.COLUMNS
            WHERE TABLE_NAME = @tableName
              AND IS_NULLABLE = 'NO'";

			SqlCommand command = new SqlCommand(query, connection);
			command.Parameters.AddWithValue("@tableName", table_name);

			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
				notNullColumns.Add(reader.GetString(0));
			connection.Close();
			return notNullColumns;
		}

		void GetNamesFields(SqlConnection connection)
		{
			connection.Open();
			string cmd = $"SELECT * FROM {table_name}";
			SqlCommand command = new SqlCommand(cmd, connection);
			SqlDataReader reader = command.ExecuteReader();
			for (int i = 0; i < reader.FieldCount; i++)
			{
				columns_names.Add(reader.GetName(i));
				columns_types.Add(Convert.ToString(reader.GetFieldType(i)));
			}

			connection.Close();
		}

		int ReturnNewId(string id_name, SqlConnection connection)
		{
			string cmd = $"SELECT MAX({id_name}) FROM {table_name}";
			return Convert.ToInt32(Scalar(cmd)) + 1;
		}

		void GenericInputFields()
		{
			int top_space = 10;
			for (int i = 0; i < columns_names.Count; i++)
			{
				//	Console.WriteLine(columns_types[i]);  // показать все типы данных таблицы 
				if (columns_types[i].Contains("String"))
				{
					TextBox inputText = new TextBox();
					inputText.Left = 110;
					inputText.Top = top_space;
					inputText.Width = 100;

					AddLabel(i, top_space);

					inputText.TextChanged += ValueChanged;
					inputText.Name = $"Control {i}";
					myForm.Controls.Add(inputText);
					top_space += 30;
				}

				if (columns_types[i].Contains("Int") || columns_types[i].Contains("Byte") || columns_types[i].Contains("Decimal"))
				{
					TextBox inputDigit = new TextBox();
					inputDigit.Left = 110;
					inputDigit.Top = top_space;
					inputDigit.Width = 100;
					inputDigit.KeyPress += NumericTextBox_KeyPress;
					if (columns_names[i].Contains("_id"))
					{
						inputDigit.Text = Convert.ToString(ReturnNewId(columns_names[i], connection));
						inputDigit.Enabled = false;
						AddValueToValues(i, inputDigit.Text);
					}


					AddLabel(i, top_space);

					inputDigit.TextChanged += ValueChanged;
					inputDigit.Name = $"Control {i}";
					myForm.Controls.Add(inputDigit);
					top_space += 30;
				}

				if (columns_types[i].Contains("Date"))
				{
					DateTimePicker inputDate = new DateTimePicker();
					inputDate.Left = 110;
					inputDate.Top = top_space;
					inputDate.Width = 100;
					inputDate.Format = DateTimePickerFormat.Short;

					AddLabel(i, top_space);

					inputDate.ValueChanged += ValueChanged;
					inputDate.Name = $"Control {i}";
					myForm.Controls.Add(inputDate);
					top_space += 30;
				}

				if (columns_types[i].Contains("TimeSpan"))
				{
					DateTimePicker inputTime = new DateTimePicker();
					inputTime.Left = 110;
					inputTime.Top = top_space;
					inputTime.Width = 100;
					inputTime.Format = DateTimePickerFormat.Time;

					AddLabel(i, top_space);

					inputTime.ValueChanged += ValueChanged;
					inputTime.Name = $"Control {i}";
					myForm.Controls.Add(inputTime);
					top_space += 30;
				}





			}
		}

		private void ValueChanged(object sender, EventArgs e)
		{
			Control control = sender as Control;
			string name = control.Name;
			int i = Convert.ToInt32(name.Substring(name.Length - 1));

			AddValueToValues(i, control.Text);
		}


		void AddValueToValues(int i, string value) => values[i] = value;

		void AddLabel(int index, int top_space)
		{
			Label label = new Label();
			label.Text = columns_names[index];
			label.Left = 10;
			label.Top = top_space;
			label.Width = 100;
			myForm.Controls.Add(label);
			myForm.Height += 10;
		}

		private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void preparation_str_for_query()
		{
			for (int i = 0; i < columns_names.Count; i++)
			{

					if (columns_names[i] == "group")
					{
						columns_names[i] = $"[{columns_names[i]}]";
						Console.WriteLine(columns_names[i]);
					}

				if (columns_types[i].Contains("String") || columns_types[i].Contains("Data") || columns_types[i].Contains("Time"))
				{


					if (!String.IsNullOrEmpty(values[i]))
					{
						values[i] = $"N'{values[i]}'" ;
					}
				}

			}

			for (int i = 0; i < columns_names.Count; i++)
			{
				if (!String.IsNullOrEmpty(values[i]))
				{
					if (i != 0)
					{
						not_null_fields_for_insert += ',';
						not_null_values_for_insert += ',';
					}
					not_null_fields_for_insert += columns_names[i];
					not_null_values_for_insert += values[i];
				}
			}
		}

		object Scalar(string cmd)
		{
			connection.Open();

			SqlCommand command = new SqlCommand(cmd, connection);
			object obj = command.ExecuteScalar();
			connection.Close();

			return obj;
		}

		public void ShowForm() => this.myForm.Show();

		void Insert(string table, string fields, string values)
		{
			string primary_key = Scalar
				(
				$@"SELECT COLUMN_NAME
				FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
				WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA+'.'+QUOTENAME(CONSTRAINT_NAME)),'IsPrimaryKey')=1
				AND   TABLE_NAME='{table}'"
				) as string;

			Console.WriteLine("\n=======================\n");
			Console.WriteLine(primary_key);
			Console.WriteLine("\n=======================\n");

			string[] fields_for_check = fields.Split(',');
			string[] values_for_check = values.Split(',');
			string condition = "";
			for (int i = 1; i < fields_for_check.Length; i++)
			{
				condition += $" {fields_for_check[i]}={values_for_check[i]} AND";

			}

			condition = condition.Remove(condition.LastIndexOf(' '), 4);

			string cmd =
$"IF NOT EXISTS(SELECT {primary_key} FROM {table} WHERE {condition} )BEGIN INSERT {table}({fields}) VALUES({values});END";

			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();

		}




		/*
System.Int16
System.Byte[]
System.Decimal

System.String
System.DateTime
System.TimeSpan



		 */





	}
}
