using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace ADO_NETT
{
	internal class Connector
	{
		private readonly string _connectionString;
		private static SqlConnection _connection;

		public Connector(string connectionString)
		{
			_connectionString = connectionString;
			try
			{
			_connection = new SqlConnection();
			_connection.ConnectionString = connectionString;
			}
			catch(Exception e) 
			{
				Console.WriteLine(e.ToString());
			}
		}

		////////////////////////////////////////////////////
		public void InsertMovie()
		{
			Console.Write("Название фильма: ");
			string movie_name = Console.ReadLine();
			Console.Write("Дата выхода ");
			string release_date = Console.ReadLine();
			Console.Write("Режисер : ");
			string director = Console.ReadLine();

			Insert
				(
				"Movies",
				"movie_id,movie_name,release_date,director",
				$"{Convert.ToInt32(Scalar("SELECT MAX(movie_id) FROM Movies")) + 1},N'{movie_name}',N'{release_date}',{GetDirectorID(director)}"
				);

			Select
				(
				"movie_name,release_date,first_name,last_name",
				"Movies,Directors",
				"director=director_id"
				);

		}

		public int GetDirectorID(string full_name)
		{
			return Convert.ToInt32(
				Scalar
				(
					$"SELECT director_id FROM Directors WHERE first_name=N'{full_name.Split(' ').First()}' AND last_name=N'{full_name.Split(' ').Last()}'"
				)
			);
		}

		public void InsertDirector()
		{
			Console.Write("Введите имя: ");
			string first_name = Console.ReadLine();

			Console.Write("Введите фамилию: ");
			string last_name = Console.ReadLine();

			Insert(
				"Directors",
				"director_id,first_name,last_name",
				$"{Convert.ToInt32(Scalar("SELECT MAX(director_id) FROM Directors")) + 1},N'{first_name}',N'{last_name}'"
				);

			Select("*", "Directors");

		}

		public void Insert(string table, string fields, string values)
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

			SqlCommand command = new SqlCommand(cmd, _connection);
			_connection.Open();
			command.ExecuteNonQuery();
			_connection.Close();

		}





		public void Select(string fields, string tables, string condition = "")
		{
			_connection.Open();
			string cmd = $"SELECT {fields} FROM {tables}";
			if (condition != "") cmd += $" WHERE {condition}";
			cmd += ";";


			SqlCommand command = new SqlCommand(cmd, _connection);
			SqlDataReader reader = command.ExecuteReader();
			for (int i = 0; i < reader.FieldCount; i++)
			{
				Console.Write(reader.GetName(i) + "\t");
			}
			Console.WriteLine();
			while (reader.Read())
			{
				for (int i = 0; i < reader.FieldCount; i++)
				{
					Console.Write(reader[i] + "\t\t");
				}
				Console.WriteLine();
			}
			reader.Close();
			_connection.Close();
		}

		public object Scalar(string cmd)
		{
			_connection.Open();

			SqlCommand command = new SqlCommand(cmd, _connection);
			object obj = command.ExecuteScalar();
			_connection.Close();

			return obj;
		}
		////////////////////////////////////////////////////





	}
}
