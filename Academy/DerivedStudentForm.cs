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
	public partial class DerivedStudentForm : BaseHumanForm
	{
		public DerivedStudentForm()
		{
			InitializeComponent();
			DataTable groups = connector.Select("*", "Groups");
			comboBoxGroup.DataSource = groups;
			comboBoxGroup.DisplayMember = groups.Columns[1].ToString();
			comboBoxGroup.ValueMember = groups.Columns[0].ToString();
		}

		public DerivedStudentForm(int id):this()
		{
			Human = new Student(id);
			Extract();
		}

		protected override void Extract()
		{
			base.Extract();
			comboBoxGroup.SelectedValue = (Human as Student).Group;
			labelID.Text = (Human as Student).ID.ToString();
		}

		protected override void buttonOK_Click(object sender, EventArgs e)
		{
			Human = new Student
				(
					textBoxLastName.Text,
					textBoxFirstName.Text,
					textBoxMiddleName.Text,
					dateTimePickerBirtDate.Text,
					textBoxEmail.Text,
					textBoxPhone.Text,
					Convert.ToInt32(comboBoxGroup.SelectedValue),
					pictureBoxPhoto.Image
				);
		}
	}
}
