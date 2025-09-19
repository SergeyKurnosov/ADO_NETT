using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NETT
{
	internal class Connector
	{
		string connectionString = "";
		SqlConnection connection;

		public Connector(string connectionString)
		{
			this.connectionString = connectionString;
			connection = new SqlConnection(connectionString);
			Console.WriteLine(connectionString);
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

			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();

		}





		public void Select(string fields, string tables, string condition = "")
		{
			//2 Открываем соединение:  После того как подключение создано оно не является открытым тоесть подключение всегда открывается вручную при необходимости

			connection.Open();

			//////////////////////////////////////////////////


			//3 Создаем SqlCommand 
			string cmd = $"SELECT {fields} FROM {tables}";
			if (condition != "") cmd += $" WHERE {condition}";
			cmd += ";";


			SqlCommand command = new SqlCommand(cmd, connection);

			//4 создаем Reader
			SqlDataReader reader = command.ExecuteReader();
			for (int i = 0; i < reader.FieldCount; i++)
			{
				Console.Write(reader.GetName(i) + "\t");
			}
			Console.WriteLine();
			while (reader.Read())
			{
				//Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}");
				for (int i = 0; i < reader.FieldCount; i++)
				{
					Console.Write(reader[i] + "\t\t");
				}
				Console.WriteLine();
			}
			reader.Close();

			//////////////////////////////////////////////////
			//? !!! Подключения обязательно нужно закрывать !!!
			connection.Close();
		}

		public object Scalar(string cmd)
		{
			connection.Open();

			SqlCommand command = new SqlCommand(cmd, connection);
			object obj = command.ExecuteScalar();
			connection.Close();

			return obj;
		}
	}
}
