using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy
{
	internal class Student:Human
	{
		public int ID {  get; set; }
		public int Group {  get; set; }
		public Student() { }
		public Student(int stud_id)
		{
			DataTable student = connector.Select("*", "Students", $"stud_id={stud_id}");
			InitFields(student, stud_id);
			ID = stud_id;
			Group = Convert.ToInt32( student.Rows[0][8] );

		}
		public Student(string last_name, string first_name, string middle_name, string birthDate, string email, string phone, int group, Image photo)
		{
			Last_name = last_name;
			First_name = first_name;
			Middle_name = middle_name;
			BirthDate = birthDate;
			Email = email;
			Phone = phone;
			Group = group;
			Photo = photo;
		}

		public override string ToString()
		{
			return $"{base.ToString()},{Group}";
		}

		public override string ToStringUpdate()
		{
			return $"{base.ToStringUpdate()},[group]={Group}";
		}
	}
}
