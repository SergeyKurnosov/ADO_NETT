using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy
{
	public partial class StudentForm : Form
	{
		internal Student Student {  get; set; }
		Connector connector;
		public StudentForm()
		{
			InitializeComponent();
			connector = new Connector();
			DataTable groups = connector.Select("*", "Groups");
			comboBoxGroup.DataSource = groups;
			comboBoxGroup.DisplayMember = groups.Columns[1].ToString();
			comboBoxGroup.ValueMember = groups.Columns[0].ToString();
		
			InitForm();
		}

		public StudentForm(int stud_id) : this()
		{

			DataTable student = connector.Select("*", "Students", $"stud_id={stud_id}");

			textBoxLastName.Text = student.Rows[0][1].ToString();
			textBoxFirstName.Text = student.Rows[0][2].ToString();
			textBoxMiddleName.Text = student.Rows[0][3].ToString();

			dateTimePickerBirtDate.Value = Convert.ToDateTime(student.Rows[0][4]);
			textBoxEmail.Text = student.Rows[0][5].ToString();
			textBoxPhone.Text = student.Rows[0][6].ToString();
			comboBoxGroup.SelectedValue = student.Rows[0][8];

			labelID.Visible = true;
			labelID.Text = $"ID: {student.Rows[0][0].ToString()}";

			try
			{
			pictureBoxPhoto.Image = connector.DownLoadPhoto(stud_id, "Students", "photo");

			}
			catch(Exception ex)
			{ 
			}

		}

		void InitForm()
		{
			textBoxLastName.Text = "Леоньтева";
			textBoxFirstName.Text = "Шарлота";
			textBoxMiddleName.Text = "Владимировна";
			dateTimePickerBirtDate.Value = new DateTime(2007, 07, 08);
			textBoxEmail.Text = "sharlott@mail.com";
			textBoxPhone.Text = "+7(123)456-77-88";
			comboBoxGroup.SelectedIndex = 10;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			Student = new Student
				(
					textBoxLastName.Text,
					textBoxFirstName.Text,
					textBoxMiddleName.Text,
					dateTimePickerBirtDate.Text,
					textBoxEmail.Text,
					textBoxPhone.Text,
					Convert.ToInt32( comboBoxGroup.SelectedValue),
					pictureBoxPhoto.Image
				);
		}

		private void buttonBroseNamePhoto_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = 
				"JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All image files|*.png;*.jpg|All files (*.*)|*.*";
		    if(	dialog.ShowDialog() == DialogResult.OK)
			{
				pictureBoxPhoto.Image = Image.FromFile( dialog.FileName);
			}
		}
	}
}
