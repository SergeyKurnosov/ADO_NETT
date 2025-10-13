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
	public partial class BaseHumanForm : Form
	{
		internal Human Human { get; set; }
		internal Connector connector;
		public BaseHumanForm()
		{
			InitializeComponent();
			connector = new Connector();
			buttonBroseNamePhoto.Click += new EventHandler(buttonBroseNamePhoto_Click);
		    buttonOK.Click += new EventHandler(buttonOK_Click);
		}

		protected virtual void Extract()
		{
			textBoxLastName.Text = Human.Last_name;
			textBoxFirstName.Text = Human.First_name;
			textBoxMiddleName.Text = Human.Middle_name;

			dateTimePickerBirtDate.Text = Human.BirthDate;
			textBoxEmail.Text = Human.Email;
			textBoxPhone.Text = Human.Phone;
			pictureBoxPhoto.Image = Human.Photo;
			labelID.Visible = true;
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

		protected virtual void buttonOK_Click(object sender, EventArgs e)
		{

		}



	}
}
