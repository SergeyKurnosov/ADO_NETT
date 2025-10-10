using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Human
	{
		public string Last_name { get; set; }
		public string First_name { get; set; }
		public string Middle_name { get; set; }
		public string BirthDate { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public Image Photo { get; set; }
		public Human() { }
		public Human(string last_name, string first_name, string middle_name, string birthDate, string email, string phone, int group, Image photo)
		{
			Last_name = last_name;
			First_name = first_name;
			Middle_name = middle_name;
			BirthDate = birthDate;
			Email = email;
			Phone = phone;
			Photo = photo;
		}
		public byte[] SerializePhoto()
		{
			MemoryStream ms = new MemoryStream();
			Photo.Save(ms, Photo.RawFormat);
			return ms.ToArray();
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
