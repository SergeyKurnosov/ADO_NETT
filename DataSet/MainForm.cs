using Academy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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

			//	dts.ds.Tables.Clear();



			tabControl.Dock = DockStyle.Fill;
			tabControl.MouseDoubleClick += tabControl_MouseDoubleClick;
			this.Controls.Add(tabControl);

			WorkTabControls();

			//string path = "D:\\ProjectHW\\ADO_NETT\\IMAGES\\garfild.jpeg";
			//byte[] bytes = File.ReadAllBytes(path);

			//DataRow row = dts.ds.Tables["Students"].NewRow();
			//row["stud_id"] = "99";
			//row["photo"] = bytes;
			//dts.ds.Tables["Students"].Rows.Add(row);



			//TabPage tabPage = new TabPage();
			//for (int i = 0; i < dts.ds.Tables.Count; i++)
			//{
			//	tabPage = new TabPage(dts.ds.Tables[i].TableName);

			//	DataGridView dataGridView = new DataGridView();
			//	dataGridView.Name = dts.ds.Tables[i].TableName;
			//	dataGridView.Top = 50;
			//	dataGridView.Width = 790;
			//	dataGridView.Height = 350;
			//	dataGridView.Anchor = AnchorStyles.Left | AnchorStyles.Top;
			//	dataGridView.DataSource = dts.ds.Tables[i];
			//	dataGridView.CellDoubleClick += DataGridViewAll_CellDoubleClick;

			//	tabPage.Controls.Add(dataGridView);

			//	Console.WriteLine(dataGridView.Name.ToString());
			//	if (dataGridView.Name == "Students")
			//	{

			//		int TopLeft = 10;
			//		ComboBox studentsGroups = Get_New_ComboBox(dts.ds.Tables["Groups"], TopLeft);
			//		studentsGroups.SelectionChangeCommitted +=
			//			(sender, e) =>
			//		{
			//			if (studentsGroups.SelectedValue.ToString() == "0")
			//				dataGridView.DataSource = dts.ds.Tables["Students"];
			//			else
			//				dataGridView.DataSource = dts.ds.Tables["Students"].Select($"group='{studentsGroups.SelectedValue}'").CopyToDataTable();
			//		};
			//		studentsGroups.SelectedIndexChanged +=
			//			(sender, e) =>
			//			{
			//				if (studentsGroups.Items.Count == 1)
			//					dataGridView.DataSource = dts.ds.Tables["Students"].Select($"group='{studentsGroups.SelectedValue}'").CopyToDataTable();
			//			};

			//		tabPage.Controls.Add(studentsGroups);
			//		TopLeft += 200;
			//		ComboBox studentsDirections = Get_New_ComboBox(dts.ds.Tables["Directions"], TopLeft);
			//		studentsDirections.SelectedIndexChanged +=
			//			(sender, e) =>
			//			{
			//				try
			//				{
			//					studentsGroups.Enabled = true;
			//					if (studentsDirections.SelectedValue.ToString() == "0")
			//						studentsGroups.DataSource = dts.ds.Tables["Groups"];
			//					else
			//						studentsGroups.DataSource = dts.ds.Tables["Groups"].Select($"direction='{studentsDirections.SelectedValue}'").CopyToDataTable();
			//				}
			//				catch (Exception ex)
			//				{
			//					Console.WriteLine(ex.Message);
			//					studentsGroups.Enabled = false;
			//				}

			//			};
			//		tabPage.Controls.Add(studentsDirections);
			//	}

			//	if (dataGridView.Name == "Disciplines")
			//	{
			//		ComboBox disciplinesDirections = Get_New_ComboBox(dts.ds.Tables["Directions"]);
			//		disciplinesDirections.SelectedIndexChanged +=
			//			(sender, e) =>
			//			{
			//				if (disciplinesDirections.SelectedValue.ToString() == "0")
			//					dataGridView.DataSource = dts.ds.Tables["Disciplines"];
			//				else
			//				{
			//					DataRow[] rows = dts.ds.Tables["DisciplinesDirectionsRelation"].Select($"direction='{disciplinesDirections.SelectedValue.ToString()}'");
			//					if (rows.Length > 0)
			//					{
			//						DataTable ddr = rows.CopyToDataTable();



			//						DataTable disciplines = dts.ds.Tables["Disciplines"];

			//						var query = from discipline in disciplines.AsEnumerable()
			//									join dd in ddr.AsEnumerable()
			//									on discipline["discipline_id"] equals dd["discipline"]
			//									select discipline;

			//						dataGridView.DataSource = query.CopyToDataTable();
			//					}
			//					else
			//					{
			//						MessageBox.Show("Not found", "Warning", MessageBoxButtons.OK);
			//					}

			//				}

			//			};
			//		tabPage.Controls.Add(disciplinesDirections);
			//	}



			//	tabControl.TabPages.Add(tabPage);
			//}



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



		[DllImport("kernel32.dll")]
		public static extern bool AllocConsole();
		[DllImport("kernel32.dll")]
		public static extern bool FreeConsole();

		private void WorkTabControls()
		{

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
				dataGridView.CellValueChanged += dataGridView1_CellValueChanged;




				tabPage.Controls.Add(dataGridView);

				Console.WriteLine(dataGridView.Name.ToString());
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
								Console.WriteLine(ex.Message);
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


				////////////////////////////////////////////////////////////////////////////
				DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn();
				comboColumn.HeaderText = "Выберите поля";
				comboColumn.Name = "comboField";
				DataTable currentTable = dataGridView.DataSource as DataTable;
				for (int c = 0; c < currentTable.Columns.Count; c++)
					comboColumn.Items.Add(currentTable.Columns[c].ColumnName.ToString());
			

				
				dataGridView.Columns.Add(comboColumn);
				/////////////////////////////////////////////////////////////////////////////


				tabControl.TabPages.Add(tabPage);


				DataGridViewColumnCollection dataGrid = dataGridView.DataSource as DataGridViewColumnCollection;
				foreach (DataGridViewColumn column in dataGrid)
				{
					column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
					int width = column.Width;
					column.MinimumWidth = 200;
				}

			}
		}


		private void DataGridViewAll_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = (sender as DataGridView).Rows[e.RowIndex];
				var id = row.Cells[0].Value;

				DinamicForm dinamicForm = new DinamicForm(tabControl.SelectedTab.Text, connection, false, Convert.ToInt32(id));
				dinamicForm.ShowForm();
			}
		}



		private void tabControl_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			TabControl tabControl = sender as TabControl;
			DinamicForm dinamicForm = new DinamicForm(tabControl.SelectedTab.Text, connection);
			dinamicForm.ShowForm();

		}

		private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView1 = sender as DataGridView;
			if (dataGridView1.Columns[e.ColumnIndex].Name == "comboField")
			{
				var selectedValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
				if (dataGridView1.Columns[selectedValue as string].Visible == true)
					dataGridView1.Columns[selectedValue as string].Visible =  false;
				else
					dataGridView1.Columns[selectedValue as string].Visible = true;

			//	DataGridViewComboBoxColumn comboBoxColumn = dataGridView1.Columns[e.ColumnIndex] as DataGridViewComboBoxColumn;
				//comboBoxColumn
			//	dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;

			}
		}


	}
}
