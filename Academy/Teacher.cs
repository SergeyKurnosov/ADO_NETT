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
	internal class Teacher:Human
	{
		public int ID { get; set; }
		public string WorkSince { get; set; }
		public string Rate { get; set; }

		public Teacher() { }

		public Teacher(int teacher_ID)
		{
			DataTable teacher = connector.Select("*", "Teachers", $"teacher_id={teacher_ID}");
			InitFields(teacher, teacher_ID, "Teachers");
			ID = teacher_ID;
			WorkSince = teacher.Rows[0][8].ToString();
			Rate = teacher.Rows[0][9].ToString();
		}

		public Teacher(string last_name, string first_name, string middle_name, string birthDate, string email, string phone, Image photo, string work_since, string rate):base(last_name,first_name,middle_name,birthDate,email,phone,photo)
		{
			WorkSince = work_since;
			Rate = rate;
		}

		public override string ToString()
		{
			return $"{base.ToString()},'{WorkSince}','{Rate}'";
		}

		public override string ToStringUpdate()
		{
			return $"{base.ToStringUpdate()},work_since='{WorkSince}',rate='{Rate}'";
		}

	}
}