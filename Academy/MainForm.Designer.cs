namespace Academy
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.tabPageTeachers = new System.Windows.Forms.TabPage();
			this.tabPageDisciplines = new System.Windows.Forms.TabPage();
			this.tabPageDirections = new System.Windows.Forms.TabPage();
			this.dataGridViewDirections = new System.Windows.Forms.DataGridView();
			this.tabPageGroups = new System.Windows.Forms.TabPage();
			this.tabPageStudents = new System.Windows.Forms.TabPage();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.dataGridViewGroups = new System.Windows.Forms.DataGridView();
			this.labelGroupsDirections = new System.Windows.Forms.Label();
			this.comboBoxGroupsDirections = new System.Windows.Forms.ComboBox();
			this.comboBoxStudentsGroups = new System.Windows.Forms.ComboBox();
			this.labelStudentsGroups = new System.Windows.Forms.Label();
			this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
			this.comboBoxStudentsDirections = new System.Windows.Forms.ComboBox();
			this.labelStudentsDirections = new System.Windows.Forms.Label();
			this.checkBoxEmptyDirections = new System.Windows.Forms.CheckBox();
			this.tabPageDirections.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDirections)).BeginInit();
			this.tabPageGroups.SuspendLayout();
			this.tabPageStudents.SuspendLayout();
			this.tabControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.Location = new System.Drawing.Point(0, 428);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(800, 22);
			this.statusStrip.TabIndex = 0;
			this.statusStrip.Text = "statusStrip1";
			// 
			// tabPageTeachers
			// 
			this.tabPageTeachers.Location = new System.Drawing.Point(4, 22);
			this.tabPageTeachers.Name = "tabPageTeachers";
			this.tabPageTeachers.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTeachers.Size = new System.Drawing.Size(792, 402);
			this.tabPageTeachers.TabIndex = 6;
			this.tabPageTeachers.Text = "Teachers";
			this.tabPageTeachers.UseVisualStyleBackColor = true;
			// 
			// tabPageDisciplines
			// 
			this.tabPageDisciplines.Location = new System.Drawing.Point(4, 22);
			this.tabPageDisciplines.Name = "tabPageDisciplines";
			this.tabPageDisciplines.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDisciplines.Size = new System.Drawing.Size(792, 402);
			this.tabPageDisciplines.TabIndex = 3;
			this.tabPageDisciplines.Text = "Disciplines";
			this.tabPageDisciplines.UseVisualStyleBackColor = true;
			// 
			// tabPageDirections
			// 
			this.tabPageDirections.Controls.Add(this.checkBoxEmptyDirections);
			this.tabPageDirections.Controls.Add(this.dataGridViewDirections);
			this.tabPageDirections.Location = new System.Drawing.Point(4, 22);
			this.tabPageDirections.Name = "tabPageDirections";
			this.tabPageDirections.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDirections.Size = new System.Drawing.Size(792, 402);
			this.tabPageDirections.TabIndex = 2;
			this.tabPageDirections.Text = "Directions";
			this.tabPageDirections.UseVisualStyleBackColor = true;
			// 
			// dataGridViewDirections
			// 
			this.dataGridViewDirections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewDirections.Location = new System.Drawing.Point(3, 34);
			this.dataGridViewDirections.Name = "dataGridViewDirections";
			this.dataGridViewDirections.Size = new System.Drawing.Size(786, 365);
			this.dataGridViewDirections.TabIndex = 0;
			// 
			// tabPageGroups
			// 
			this.tabPageGroups.Controls.Add(this.comboBoxGroupsDirections);
			this.tabPageGroups.Controls.Add(this.labelGroupsDirections);
			this.tabPageGroups.Controls.Add(this.dataGridViewGroups);
			this.tabPageGroups.Location = new System.Drawing.Point(4, 22);
			this.tabPageGroups.Name = "tabPageGroups";
			this.tabPageGroups.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGroups.Size = new System.Drawing.Size(792, 402);
			this.tabPageGroups.TabIndex = 1;
			this.tabPageGroups.Text = "Groups";
			this.tabPageGroups.UseVisualStyleBackColor = true;
			// 
			// tabPageStudents
			// 
			this.tabPageStudents.Controls.Add(this.comboBoxStudentsDirections);
			this.tabPageStudents.Controls.Add(this.labelStudentsDirections);
			this.tabPageStudents.Controls.Add(this.comboBoxStudentsGroups);
			this.tabPageStudents.Controls.Add(this.labelStudentsGroups);
			this.tabPageStudents.Controls.Add(this.dataGridViewStudents);
			this.tabPageStudents.Location = new System.Drawing.Point(4, 22);
			this.tabPageStudents.Name = "tabPageStudents";
			this.tabPageStudents.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageStudents.Size = new System.Drawing.Size(792, 402);
			this.tabPageStudents.TabIndex = 0;
			this.tabPageStudents.Text = "Students";
			this.tabPageStudents.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageStudents);
			this.tabControl1.Controls.Add(this.tabPageGroups);
			this.tabControl1.Controls.Add(this.tabPageDirections);
			this.tabControl1.Controls.Add(this.tabPageDisciplines);
			this.tabControl1.Controls.Add(this.tabPageTeachers);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(800, 428);
			this.tabControl1.TabIndex = 1;
			// 
			// dataGridViewGroups
			// 
			this.dataGridViewGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewGroups.Location = new System.Drawing.Point(18, 36);
			this.dataGridViewGroups.Name = "dataGridViewGroups";
			this.dataGridViewGroups.Size = new System.Drawing.Size(766, 317);
			this.dataGridViewGroups.TabIndex = 0;
			// 
			// labelGroupsDirections
			// 
			this.labelGroupsDirections.AutoSize = true;
			this.labelGroupsDirections.Location = new System.Drawing.Point(15, 10);
			this.labelGroupsDirections.Name = "labelGroupsDirections";
			this.labelGroupsDirections.Size = new System.Drawing.Size(124, 13);
			this.labelGroupsDirections.TabIndex = 1;
			this.labelGroupsDirections.Text = "Направление обучения";
			// 
			// comboBoxGroupsDirections
			// 
			this.comboBoxGroupsDirections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxGroupsDirections.FormattingEnabled = true;
			this.comboBoxGroupsDirections.Location = new System.Drawing.Point(145, 7);
			this.comboBoxGroupsDirections.Name = "comboBoxGroupsDirections";
			this.comboBoxGroupsDirections.Size = new System.Drawing.Size(316, 21);
			this.comboBoxGroupsDirections.TabIndex = 2;
			this.comboBoxGroupsDirections.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroupsDirections_SelectedIndexChanged);
			// 
			// comboBoxStudentsGroups
			// 
			this.comboBoxStudentsGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxStudentsGroups.FormattingEnabled = true;
			this.comboBoxStudentsGroups.Location = new System.Drawing.Point(63, 16);
			this.comboBoxStudentsGroups.Name = "comboBoxStudentsGroups";
			this.comboBoxStudentsGroups.Size = new System.Drawing.Size(115, 21);
			this.comboBoxStudentsGroups.TabIndex = 5;
			this.comboBoxStudentsGroups.SelectedIndexChanged += new System.EventHandler(this.comboBoxStudentsGroups_SelectedIndexChanged);
			// 
			// labelStudentsGroups
			// 
			this.labelStudentsGroups.AutoSize = true;
			this.labelStudentsGroups.Location = new System.Drawing.Point(15, 20);
			this.labelStudentsGroups.Name = "labelStudentsGroups";
			this.labelStudentsGroups.Size = new System.Drawing.Size(42, 13);
			this.labelStudentsGroups.TabIndex = 4;
			this.labelStudentsGroups.Text = "Группа";
			// 
			// dataGridViewStudents
			// 
			this.dataGridViewStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewStudents.Location = new System.Drawing.Point(15, 57);
			this.dataGridViewStudents.Name = "dataGridViewStudents";
			this.dataGridViewStudents.Size = new System.Drawing.Size(766, 317);
			this.dataGridViewStudents.TabIndex = 3;
			// 
			// comboBoxStudentsDirections
			// 
			this.comboBoxStudentsDirections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxStudentsDirections.FormattingEnabled = true;
			this.comboBoxStudentsDirections.Location = new System.Drawing.Point(358, 16);
			this.comboBoxStudentsDirections.Name = "comboBoxStudentsDirections";
			this.comboBoxStudentsDirections.Size = new System.Drawing.Size(316, 21);
			this.comboBoxStudentsDirections.TabIndex = 7;
			this.comboBoxStudentsDirections.SelectedIndexChanged += new System.EventHandler(this.comboBoxStudentsDirections_SelectedIndexChanged);
			// 
			// labelStudentsDirections
			// 
			this.labelStudentsDirections.AutoSize = true;
			this.labelStudentsDirections.Location = new System.Drawing.Point(228, 20);
			this.labelStudentsDirections.Name = "labelStudentsDirections";
			this.labelStudentsDirections.Size = new System.Drawing.Size(124, 13);
			this.labelStudentsDirections.TabIndex = 6;
			this.labelStudentsDirections.Text = "Направление обучения";
			// 
			// checkBoxEmptyDirections
			// 
			this.checkBoxEmptyDirections.AutoSize = true;
			this.checkBoxEmptyDirections.Location = new System.Drawing.Point(23, 7);
			this.checkBoxEmptyDirections.Name = "checkBoxEmptyDirections";
			this.checkBoxEmptyDirections.Size = new System.Drawing.Size(183, 17);
			this.checkBoxEmptyDirections.TabIndex = 1;
			this.checkBoxEmptyDirections.Text = "Показать пустые направления";
			this.checkBoxEmptyDirections.UseVisualStyleBackColor = true;
			this.checkBoxEmptyDirections.CheckedChanged += new System.EventHandler(this.checkBoxEmptyDirections_CheckedChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.statusStrip);
			this.Name = "MainForm";
			this.Text = "Academy PD_411";
			this.tabPageDirections.ResumeLayout(false);
			this.tabPageDirections.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDirections)).EndInit();
			this.tabPageGroups.ResumeLayout(false);
			this.tabPageGroups.PerformLayout();
			this.tabPageStudents.ResumeLayout(false);
			this.tabPageStudents.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.TabPage tabPageTeachers;
		private System.Windows.Forms.TabPage tabPageDisciplines;
		private System.Windows.Forms.TabPage tabPageDirections;
		private System.Windows.Forms.TabPage tabPageGroups;
		private System.Windows.Forms.TabPage tabPageStudents;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.DataGridView dataGridViewDirections;
		private System.Windows.Forms.DataGridView dataGridViewGroups;
		private System.Windows.Forms.ComboBox comboBoxGroupsDirections;
		private System.Windows.Forms.Label labelGroupsDirections;
		private System.Windows.Forms.ComboBox comboBoxStudentsGroups;
		private System.Windows.Forms.Label labelStudentsGroups;
		private System.Windows.Forms.DataGridView dataGridViewStudents;
		private System.Windows.Forms.ComboBox comboBoxStudentsDirections;
		private System.Windows.Forms.Label labelStudentsDirections;
		private System.Windows.Forms.CheckBox checkBoxEmptyDirections;
	}
}

