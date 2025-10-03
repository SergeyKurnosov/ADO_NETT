using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSet
{
	public partial class MainForm : Form
	{
		string connectionString = "";
		SqlConnection connection = null;
		DTS dts;
		TabControl tabControl = new TabControl();

		public MainForm()
		{
			InitializeComponent();
			connectionString = ConfigurationManager.ConnectionStrings["PD_321"].ConnectionString;
			connection = new SqlConnection(connectionString);

			AllocConsole();

			dts = new DTS(connectionString, connection);
			dts.Generic_Table("Students");
			dts.Generic_Table("Teachers");
			dts.Generic_Table("DisciplinesDirectionsRelation");


			
			tabControl.Dock = DockStyle.Fill;
			this.Controls.Add(tabControl);

			string path = "D:\\ProjectHW\\ADO_NETT\\IMAGES\\garfild.jpeg";
			byte[] bytes = File.ReadAllBytes(path);

			DataRow row = dts.ds.Tables["Students"].NewRow();
			row["stud_id"] = "99";
			row["photo"] = bytes;

		//	Console.WriteLine(dts.ds.Tables["Students"].Columns["photo"].DataType);
			dts.ds.Tables["Students"].Rows.Add(row);



		//	dts.ds.Tables["Students"]


			TabPage tabPage = new TabPage();
			for (int i = 0; i < dts.ds.Tables.Count; i++)
			{
				tabPage = new TabPage(dts.ds.Tables[i].TableName);

				DataGridView dataGridView = new DataGridView();
				dataGridView.Name = dts.ds.Tables[i].TableName;
				dataGridView.Top = 50;
				dataGridView.Width = 790;
				dataGridView.Height = 350;
				dataGridView.Anchor = AnchorStyles.Left | AnchorStyles.Top;
				dataGridView.DataSource = dts.ds.Tables[i];
				dataGridView.CellDoubleClick += DataGridViewAll_CellDoubleClick;

				tabPage.Controls.Add(dataGridView);

				if (dataGridView.Name == "Students")
				{
					int TopLeft = 10;
					ComboBox studentsGroups = Get_New_ComboBox(dts.ds.Tables["Groups"], TopLeft);
					studentsGroups.SelectionChangeCommitted +=
						(sender, e) =>
					{
						if (studentsGroups.SelectedValue.ToString() == "0")
							dataGridView.DataSource = dts.ds.Tables["Students"];
						else
							dataGridView.DataSource = dts.ds.Tables["Students"].Select($"group='{studentsGroups.SelectedValue}'").CopyToDataTable();
					};
					studentsGroups.SelectedIndexChanged +=
						(sender, e) =>
						{
							if (studentsGroups.Items.Count == 1)
								dataGridView.DataSource = dts.ds.Tables["Students"].Select($"group='{studentsGroups.SelectedValue}'").CopyToDataTable();
						};

					tabPage.Controls.Add(studentsGroups);
					TopLeft += 200;
					ComboBox studentsDirections = Get_New_ComboBox(dts.ds.Tables["Directions"], TopLeft);
					studentsDirections.SelectedIndexChanged +=
						(sender, e) =>
						{
							try
							{
								studentsGroups.Enabled = true;
								if (studentsDirections.SelectedValue.ToString() == "0")
									studentsGroups.DataSource = dts.ds.Tables["Groups"];
								else
									studentsGroups.DataSource = dts.ds.Tables["Groups"].Select($"direction='{studentsDirections.SelectedValue}'").CopyToDataTable();
							}
							catch (Exception ex)
							{
								studentsGroups.Enabled = false;
							}

						};
					tabPage.Controls.Add(studentsDirections);
				}

				if (dataGridView.Name == "Disciplines")
				{
					ComboBox disciplinesDirections = Get_New_ComboBox(dts.ds.Tables["Directions"]);
					disciplinesDirections.SelectedIndexChanged +=
						(sender, e) =>
						{
							if (disciplinesDirections.SelectedValue.ToString() == "0")
								dataGridView.DataSource = dts.ds.Tables["Disciplines"];
							else
							{
								DataRow[] rows = dts.ds.Tables["DisciplinesDirectionsRelation"].Select($"direction='{disciplinesDirections.SelectedValue.ToString()}'");
								if (rows.Length > 0)
								{
									DataTable ddr = rows.CopyToDataTable();



									DataTable disciplines = dts.ds.Tables["Disciplines"];

									var query = from discipline in disciplines.AsEnumerable()
												join dd in ddr.AsEnumerable()
												on discipline["discipline_id"] equals dd["discipline"]
												select discipline;

									dataGridView.DataSource = query.CopyToDataTable();
								}
								else
								{
									MessageBox.Show("Not found", "Warning", MessageBoxButtons.OK);
								}

							}

						};
					tabPage.Controls.Add(disciplinesDirections);
				}



				tabControl.TabPages.Add(tabPage);
			}
		}

		ComboBox Get_New_ComboBox(DataTable table_orign, int TopLeft = 10)
		{
			DataTable table = table_orign.Copy();
			DataRow allRow = table.NewRow();
			allRow[0] = 0;
			allRow[1] = "Все";
			table.Rows.InsertAt(allRow, 0);
			ComboBox cb = new ComboBox();
			cb.Name = table.TableName;
			cb.Left = TopLeft;
			cb.DataSource = table;
			cb.DisplayMember = table.Columns[1].ToString();
			cb.ValueMember = table.Columns[0].ToString();
			return cb;
		}


		private void DataGridViewAll_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = (sender as DataGridView).Rows[e.RowIndex];
				
				var id = row.Cells[0].Value;

				PictureBox pictureBox = new PictureBox();

				pictureBox.Width = 200;
				pictureBox.Height = 200; 

				pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
			//	pictureBox.Location = new Point(10, 10);


				DataRow dataRow = dts.ds.Tables[tabControl.SelectedTab.Text].Select($"stud_id='{Convert.ToInt32(id)}'").First();

				byte[] imageBytes = (byte[])dataRow["photo"];

				using (MemoryStream ms = new MemoryStream(imageBytes))
				{
					ms.Position = 0;
					pictureBox.Image = Image.FromStream(ms);

				}
				Form form = new Form();
				form.Height = pictureBox.Height;
				form.Width = pictureBox.Width;	
				form.Controls.Add(pictureBox);
				form.ShowDialog();
			//	this.Controls.Add(pictureBox);
			//	tabControl.Controls.Add(pictureBox);
			//	tabControl.SelectedTab.Controls.Add(pictureBox);

			//	pictureBox.Show();


			//	DinamicForm dinamicForm = new DinamicForm(tabControl.SelectedTab.Text, connection, false, Convert.ToInt32(id));
			//	dinamicForm.ShowForm();
			}
		}






		[DllImport("kernel32.dll")]
		public static extern bool AllocConsole();
		[DllImport("kernel32.dll")]
		public static extern bool FreeConsole();



	}
}
