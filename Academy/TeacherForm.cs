using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy
{
	public partial class TeacherForm : Form
	{
		internal Teacher Teacher { get; set; }
		Connector connector;

		public TeacherForm()
		{
			InitializeComponent();
			connector = new Connector();
			InitForm();
		}

		public TeacherForm(int teacher_id):this()
		{
			DataTable teacher = connector.Select("*", "Teachers", $"teacher_id={teacher_id}");

			textBoxLastName.Text = teacher.Rows[0][1].ToString();
			textBoxFirstName.Text = teacher.Rows[0][2].ToString();
			textBoxMiddleName.Text = teacher.Rows[0][3].ToString();

			dateTimePickerBirtDate.Value = Convert.ToDateTime(teacher.Rows[0][4]);
			textBoxEmail.Text = teacher.Rows[0][5].ToString();
			textBoxPhone.Text = teacher.Rows[0][6].ToString();
			dateTimePickerWorkSince.Value = Convert.ToDateTime( teacher.Rows[0][8]);
			textBoxRate.Text = teacher.Rows[0][9].ToString();

			labelID.Visible = true;
			labelID.Text = $"ID: {teacher.Rows[0][0].ToString()}";
			try
			{
				pictureBoxPhoto.Image = connector.DownLoadPhoto(teacher_id, "Teachers", "photo");

			}
			catch (Exception ex)
			{}
		}




		void InitForm()
		{
			textBoxLastName.Text = "Фамилия";
			textBoxFirstName.Text = "Имя";
			textBoxMiddleName.Text = "Отчество";
			dateTimePickerBirtDate.Value = new DateTime(2007, 07, 08);
			textBoxEmail.Text = "kakaiato_pochta@mail.com";
			textBoxPhone.Text = "+7(123)456-77-88";
			dateTimePickerWorkSince.Value = new DateTime(2005, 08, 07);
		}


		private void buttonBroseNamePhoto_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter =
				"JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All image files|*.png;*.jpg|All files (*.*)|*.*";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				pictureBoxPhoto.Image = Image.FromFile(dialog.FileName);


			}



		}

		private void buttonBroseNamePhoto_Click_1(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter =
				"JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All image files|*.png;*.jpg|All files (*.*)|*.*";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				pictureBoxPhoto.Image = Image.FromFile(dialog.FileName);


			}
		}

		private void buttonOK_Click_1(object sender, EventArgs e)
		{
			Teacher = new Teacher
				(
					textBoxLastName.Text,
					textBoxFirstName.Text,
					textBoxMiddleName.Text,
					dateTimePickerBirtDate.Text,
					textBoxEmail.Text,
					textBoxPhone.Text,
					pictureBoxPhoto.Image,
					dateTimePickerWorkSince.Text,
					textBoxRate.Text
				);
		}
	}
}
