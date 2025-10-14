using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Human
	{
		public Connector connector = new Connector();
		public string Last_name { get; set; }
		public string First_name { get; set; }
		public string Middle_name { get; set; }
		public string BirthDate { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public Image Photo { get; set; }
		public Human() { }
		public Human(string last_name, string first_name, string middle_name, string birthDate, string email, string phone, Image photo)
		{
			Last_name = last_name;
			First_name = first_name;
			Middle_name = middle_name;
			BirthDate = birthDate;
			Email = email;
			Phone = phone;
			Photo = photo;
		//	connector = new Connector();
		}
		public byte[] SerializePhoto()
		{
			MemoryStream ms = new MemoryStream();
			Photo.Save(ms, Photo.RawFormat);
			return ms.ToArray();
		}

		protected void InitFields(DataTable table, int id, string table_name)
		{
			Last_name = table.Rows[0][1].ToString();
			First_name = table.Rows[0][2].ToString();
			Middle_name = table.Rows[0][3].ToString();
			BirthDate = table.Rows[0][4].ToString();
			Email = table.Rows[0][5].ToString();
			Phone = table.Rows[0][6].ToString();
			try
			{
				Photo = connector.DownLoadPhoto(id, table_name, "photo");
			}
			catch (Exception)
			{
			}
		}

		public override string ToString()
		{
			return $"N'{Last_name}',N'{First_name}',N'{Middle_name}','{BirthDate}',N'{Email}',N'{Phone}'";
		}

		public virtual string ToStringUpdate()
		{
			return $@"
last_name=N'{Last_name}',
first_name=N'{First_name}',
middle_name=N'{Middle_name}',
birth_date='{BirthDate}',
email=N'{Email}',
phone=N'{Phone}'
";
		}
	}
}
