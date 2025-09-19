//#define SCALAR_CHECK
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
		static readonly	string connectionString = "Data Source=SERGEY\\MSSQLSERVER17;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		

		static void Main(string[] args)
		{
			Connector connector = new Connector(connectionString);

			connector.InsertDirector();
			connector.InsertMovie();
			


			connector.Select("*", "Directors");
			Console.WriteLine("\n\n");
			connector.Select("*", "Movies");


		}

	}
}
