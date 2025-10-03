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
			
		}

		void Compress()
		{
			Student.Last_name = textBoxLastName.Text;
			Student.First_name = textBoxFirstName.Text;
			Student.Middle_name = textBoxMiddleName.Text;
			Student.Email = textBoxEmail.Text;
			Student.Phone = textBoxPhone.Text;
			Student.Group = Convert.ToInt32(comboBoxGroup.SelectedValue);
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
					Convert.ToInt32( comboBoxGroup.SelectedValue)

				);
		}
	}
}
