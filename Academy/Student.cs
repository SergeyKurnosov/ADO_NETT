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

using DataBaseTools;

namespace Academy
{
	internal class Student:Human
	{
		public int ID {  get; set; }
		public int Group {  get; set; }
		public Student() { }
		public Student(int stud_id)
		{
			Connector connector = new Connector();
			DataTable student = connector.Select("*", "Students", $"stud_id={stud_id}");
			ID = stud_id;
			Last_name = student.Rows[0][1].ToString();
			First_name = student.Rows[0][2].ToString();
			Middle_name = student.Rows[0][3].ToString();
			BirthDate = student.Rows[0][4].ToString();
			Email = student.Rows[0][5].ToString();
			Phone = student.Rows[0][6].ToString();
			Group = Convert.ToInt32( student.Rows[0][8] );
			try
			{
				Photo = connector.DownLoadPhoto(stud_id, "Students", "photo");
			}
			catch(Exception)
			{
			}
			
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
