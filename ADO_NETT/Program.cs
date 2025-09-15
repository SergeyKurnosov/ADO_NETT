using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ado.net
using System.Data.SqlClient;

namespace ADO_NETT
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//1 Создаем подключение к базе данных на сервере
			string connectionString = "Data Source=SERGEY\\MSSQLSERVER17;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
			Console.WriteLine(connectionString);
			SqlConnection connection = new SqlConnection();
			connection.ConnectionString = connectionString;
			//2 Открываем соединение:  После того как подключение создано оно не является открытым тоесть подключение всегда открывается вручную при необходимости
			connection.Open();

			//////////////////////////////////////////////////


			//3 Создаем SqlCommand 
			string cmd = "SELECT * FROM Directors;";
			SqlCommand command = new SqlCommand(cmd, connection);

			//4 создаем Reader
			SqlDataReader reader = command.ExecuteReader();
			for (int i = 0;i<reader.FieldCount; i++)
			{
				Console.Write(reader.GetName(i) + "\t");
			}
			Console.WriteLine();
			while (reader.Read())
			{
				//Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}");
				for (int i = 0; i < reader.FieldCount; i++)
				{
					Console.Write(reader[i]+"\t\t");
				}
				Console.WriteLine();
			}
			reader.Close();

			//////////////////////////////////////////////////
			//? !!! Подключения обязательно нужно закрывать !!!
			connection.Close();

		}
	}
}
