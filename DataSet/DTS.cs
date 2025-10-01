using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSet
{
	internal class DTS
	{
		public readonly string connectionString;
		//	public readonly string tableName;
		SqlConnection conn;
		public System.Data.DataSet ds;

		public DTS(string connectionString, SqlConnection connection)
		{
			this.connectionString = connectionString;
			this.conn = connection;
			this.ds = new System.Data.DataSet(nameof(ds));
		}

		public DataTable Generic_Table(string table_name)
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = table_name;
			List<string> columns_names = Get_Column_Names(table_name);
			List<string> foreign_key_names = Get_Names_Foreign_Keys(table_name);
			List<string> foreign_key_fields = new List<string>();
			for (int i = 0; i < foreign_key_names.Count; i++)
			{
				foreign_key_fields.Add(Get_Name_Field_Foreign_Keys(table_name, foreign_key_names[i]));
	
			}
			string primary_key_field = Get_Name_Primary_Key(table_name);


			Console.WriteLine("\nall columns:");
			for (int i = 0; i < columns_names.Count; i++)
			{
				Console.WriteLine(columns_names[i]);
			}
			Console.WriteLine("\npk:");
			Console.WriteLine(primary_key_field);
			for (int i = 0; i < foreign_key_names.Count; i++)
			{
				Console.WriteLine("\nname fk:");
				Console.WriteLine(foreign_key_names[i]);
				Console.WriteLine("\nfield fk:");
				Console.WriteLine(Get_Name_Field_Foreign_Keys(table_name, foreign_key_names[i]));
			}

			////////////////////////////////////////////////////////
			for (int i = 0; i < columns_names.Count; i++)
			{
				dataTable.Columns.Add(columns_names[i]);
			}
			dataTable.PrimaryKey =
				new DataColumn[] { dataTable.Columns[primary_key_field] };

			ds.Tables.Add(dataTable);

			for (int i = 0; i < foreign_key_names.Count; i++)
			{
				string[] arr_relation = foreign_key_names[i].Split('_');

				if(!ds.Tables.Contains(arr_relation[arr_relation.Length-1]))
				{
					Generic_Table(arr_relation[arr_relation.Length - 1]);
				}
				ds.Relations.Add
					(
					foreign_key_names[i],
					ds.Tables[arr_relation[arr_relation.Length - 1]].Columns[Get_Name_Primary_Key(arr_relation[arr_relation.Length - 1])],
					ds.Tables[table_name].Columns[foreign_key_fields[i]]
					);
			}

			string query = $"SELECT * FROM {table_name}";
			SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
			adapter.Fill(ds.Tables[table_name]);



			return dataTable;
		}

		public List<string> Get_Column_Names(string table_name)
		{
			string query = $"SELECT * FROM {table_name}";
			List<string> columns = new List<string>();
			SqlCommand cmd = new SqlCommand(query, conn);
			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader();

			for (int i = 0; i < reader.FieldCount; i++)
				columns.Add(reader.GetName(i));

			conn.Close();

			return columns;
		}

		public string Get_Name_Primary_Key(string table_name)
		{
			conn.Open();
			string columnName = "";
			DataTable relationsSchema = conn.GetSchema("IndexColumns", new string[] { null, null, table_name });
			foreach (DataRow row in relationsSchema.Rows)
			{
				columnName = (string)row["COLUMN_NAME"];
			}
			conn.Close();
			return columnName;
		}

		public List<string> Get_Names_Foreign_Keys(string table_name)
		{
				conn.Open();
			DataTable relationsSchema = conn.GetSchema("ForeignKeys", new string[] { null, null, table_name });
			List<string> foreign_keys = new List<string>();
			foreach (DataRow row in relationsSchema.Rows)
			{
				string columnName = (string)row["CONSTRAINT_NAME"];
				foreign_keys.Add(columnName);
			}
				conn.Close();
			return foreign_keys;
		}

		public string Get_Name_Field_Foreign_Keys(string table_name, string name_foreign_key)
		{
			string query =
				"\t\t     " +
				"SELECT \r\n             " +
				"kcu.COLUMN_NAME,\r\n             " +
				"kcu.CONSTRAINT_NAME\r\n             " +
				"FROM \r\n             " +
				"INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS kcu\r\n             " +
				"WHERE \r\n             " +
				$"kcu.TABLE_NAME = '{table_name}' \r\n             AND kcu.CONSTRAINT_NAME = '{name_foreign_key}'  ";

			
			SqlCommand cmd = new SqlCommand(query, conn);
			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader();
			string result = "";
			while (reader.Read())
			{
				result = reader[0].ToString();
			}

			conn.Close() ;
			return result;
		}

		public void Vivodilka()
		{
			DataRow[] RPO = ds.Tables["Directions"].Rows[0].GetChildRows("FK_Groups_Directions");
			for (int i = 0; i < RPO.Length; i++)
			{
				for (int j = 0; j < RPO[i].ItemArray.Length; j++)
				{
					Console.Write($"{RPO[i].ItemArray[j]}\t\t");
				}
				Console.WriteLine();
			}



			foreach (DataRow row in ds.Tables["Directions"].Rows)
			{
				Console.WriteLine($"{row["direction_id"]}\t{row["direction_name"]}");
			}



		}







	}
}
