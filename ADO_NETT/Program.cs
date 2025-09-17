using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADO_NETT
{
	internal class Program
	{
		static string connectionString = "Data Source=SERGEY\\MSSQLSERVER17;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		static SqlConnection connection;

		static void Main(string[] args)
		{
			Console.WriteLine(connectionString);
			connection = new SqlConnection();
			connection.ConnectionString = connectionString;

			Insert_2("director_id,first_name,last_name", "Directors", "13,NewDir,Dir");

			//Console.Write("Введите имя: ");
			//string first_name = Console.ReadLine();
			//Console.Write("Введите фамилию: ");
			//string last_name = Console.ReadLine();
			//int rowsAffected = Insert(first_name, last_name);

			// Select_Parametrs("*", "Directors","first_name", "James");

		    	Select("*", "Directors");

		}

		static int Insert(string first_name, string last_name)
		{
			string cmd =
$"INSERT Directors(director_id,first_name,last_name) VALUES({Convert.ToInt32(Scalar("SELECT MAX(director_id) FROM Directors")) + 1},N'{first_name}',N'{last_name}');";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			int rowsAffected = command.ExecuteNonQuery();
			connection.Close();

			return rowsAffected;
		}

		static int Insert_2(string fields, string table, string datas) 
		{
			connection.Open();
			string cmd_Insert = $"INSERT {table}({fields}) VALUES(";
			string cmd = $"SELECT {fields} FROM {table}";
			string[] values = datas.Split(',') ;

			SqlCommand command = new SqlCommand(cmd, connection);
			SqlDataReader reader = command.ExecuteReader();
			for (int i = 0; i < reader.FieldCount; i++)
			{
				switch (Type.GetTypeCode(reader.GetFieldType(i)))
				{
					case TypeCode.String:
						cmd_Insert += $"N'{values[i]}',";
						break;
					case TypeCode.Int32:
						cmd_Insert += $"{values[i]},";
						break;
					case TypeCode.DateTime:
						cmd_Insert += $"{values[i]},";
						break;
				}
			}
			reader.Close();
			cmd_Insert = cmd_Insert.Substring(0, cmd_Insert.Length - 1) ;
			cmd_Insert += ");";

			command.CommandText = cmd_Insert ;
			int rowsAffected = command.ExecuteNonQuery();
			connection.Close();

			return rowsAffected;
		}

		static void Select_Parametrs(string fields, string tables, string search_field, string search = "")
		{
			connection.Open();
			string cmd = $"SELECT {fields} FROM {tables} WHERE {search_field} = @search ;";//


			SqlCommand command = new SqlCommand(cmd, connection);
			command.Parameters.AddWithValue("@search", search);

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
			connection.Close();
		}


//--------------------------------------------------------------------------------------------------------------

		static void Select(string fields, string tables, string condition = "")
		{
			connection.Open();
			string cmd = $"SELECT {fields} FROM {tables}";
			if (condition != "") cmd += $" WHERE {condition}";
			cmd += ";";


			SqlCommand command = new SqlCommand(cmd, connection);
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
			connection.Close();
		}

		static object Scalar(string cmd)
		{
			connection.Open();

			SqlCommand command = new SqlCommand(cmd, connection);
			object obj = command.ExecuteScalar();
			connection.Close();

			return obj;
		}
	}
}
