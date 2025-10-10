namespace Academy
{
	partial class TeacherForm
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
			this.labelID = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonBroseNamePhoto = new System.Windows.Forms.Button();
			this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
			this.textBoxPhone = new System.Windows.Forms.TextBox();
			this.textBoxEmail = new System.Windows.Forms.TextBox();
			this.dateTimePickerBirtDate = new System.Windows.Forms.DateTimePicker();
			this.textBoxMiddleName = new System.Windows.Forms.TextBox();
			this.textBoxFirstName = new System.Windows.Forms.TextBox();
			this.textBoxLastName = new System.Windows.Forms.TextBox();
			this.labelPhone = new System.Windows.Forms.Label();
			this.labelEmail = new System.Windows.Forms.Label();
			this.labelBirthDate = new System.Windows.Forms.Label();
			this.labelMiddleName = new System.Windows.Forms.Label();
			this.labelFirstName = new System.Windows.Forms.Label();
			this.labelLastName = new System.Windows.Forms.Label();
			this.dateTimePickerWorkSince = new System.Windows.Forms.DateTimePicker();
			this.labelWorkSince = new System.Windows.Forms.Label();
			this.textBoxRate = new System.Windows.Forms.TextBox();
			this.labelRate = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
			this.SuspendLayout();
			// 
			// labelID
			// 
			this.labelID.AutoSize = true;
			this.labelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelID.Location = new System.Drawing.Point(12, 372);
			this.labelID.Name = "labelID";
			this.labelID.Size = new System.Drawing.Size(27, 24);
			this.labelID.TabIndex = 37;
			this.labelID.Text = "ID";
			this.labelID.Visible = false;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(480, 297);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 36;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(399, 297);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 35;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click_1);
			// 
			// buttonBroseNamePhoto
			// 
			this.buttonBroseNamePhoto.Location = new System.Drawing.Point(268, 343);
			this.buttonBroseNamePhoto.Name = "buttonBroseNamePhoto";
			this.buttonBroseNamePhoto.Size = new System.Drawing.Size(75, 23);
			this.buttonBroseNamePhoto.TabIndex = 34;
			this.buttonBroseNamePhoto.Text = "Обзор";
			this.buttonBroseNamePhoto.UseVisualStyleBackColor = true;
			this.buttonBroseNamePhoto.Click += new System.EventHandler(this.buttonBroseNamePhoto_Click_1);
			// 
			// pictureBoxPhoto
			// 
			this.pictureBoxPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxPhoto.Location = new System.Drawing.Point(399, 12);
			this.pictureBoxPhoto.Name = "pictureBoxPhoto";
			this.pictureBoxPhoto.Size = new System.Drawing.Size(218, 266);
			this.pictureBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxPhoto.TabIndex = 33;
			this.pictureBoxPhoto.TabStop = false;
			// 
			// textBoxPhone
			// 
			this.textBoxPhone.Location = new System.Drawing.Point(98, 215);
			this.textBoxPhone.Name = "textBoxPhone";
			this.textBoxPhone.Size = new System.Drawing.Size(245, 20);
			this.textBoxPhone.TabIndex = 31;
			// 
			// textBoxEmail
			// 
			this.textBoxEmail.Location = new System.Drawing.Point(98, 172);
			this.textBoxEmail.Name = "textBoxEmail";
			this.textBoxEmail.Size = new System.Drawing.Size(245, 20);
			this.textBoxEmail.TabIndex = 30;
			// 
			// dateTimePickerBirtDate
			// 
			this.dateTimePickerBirtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerBirtDate.Location = new System.Drawing.Point(98, 140);
			this.dateTimePickerBirtDate.Name = "dateTimePickerBirtDate";
			this.dateTimePickerBirtDate.Size = new System.Drawing.Size(245, 20);
			this.dateTimePickerBirtDate.TabIndex = 29;
			// 
			// textBoxMiddleName
			// 
			this.textBoxMiddleName.Location = new System.Drawing.Point(98, 95);
			this.textBoxMiddleName.Name = "textBoxMiddleName";
			this.textBoxMiddleName.Size = new System.Drawing.Size(245, 20);
			this.textBoxMiddleName.TabIndex = 28;
			// 
			// textBoxFirstName
			// 
			this.textBoxFirstName.Location = new System.Drawing.Point(98, 45);
			this.textBoxFirstName.Name = "textBoxFirstName";
			this.textBoxFirstName.Size = new System.Drawing.Size(245, 20);
			this.textBoxFirstName.TabIndex = 27;
			// 
			// textBoxLastName
			// 
			this.textBoxLastName.Location = new System.Drawing.Point(98, 8);
			this.textBoxLastName.Name = "textBoxLastName";
			this.textBoxLastName.Size = new System.Drawing.Size(245, 20);
			this.textBoxLastName.TabIndex = 26;
			// 
			// labelPhone
			// 
			this.labelPhone.AutoSize = true;
			this.labelPhone.Location = new System.Drawing.Point(40, 215);
			this.labelPhone.Name = "labelPhone";
			this.labelPhone.Size = new System.Drawing.Size(52, 13);
			this.labelPhone.TabIndex = 24;
			this.labelPhone.Text = "Телефон";
			// 
			// labelEmail
			// 
			this.labelEmail.AutoSize = true;
			this.labelEmail.Location = new System.Drawing.Point(57, 172);
			this.labelEmail.Name = "labelEmail";
			this.labelEmail.Size = new System.Drawing.Size(35, 13);
			this.labelEmail.TabIndex = 23;
			this.labelEmail.Text = "E-mail";
			// 
			// labelBirthDate
			// 
			this.labelBirthDate.AutoSize = true;
			this.labelBirthDate.Location = new System.Drawing.Point(6, 144);
			this.labelBirthDate.Name = "labelBirthDate";
			this.labelBirthDate.Size = new System.Drawing.Size(86, 13);
			this.labelBirthDate.TabIndex = 22;
			this.labelBirthDate.Text = "Дата рождения";
			// 
			// labelMiddleName
			// 
			this.labelMiddleName.AutoSize = true;
			this.labelMiddleName.Location = new System.Drawing.Point(38, 98);
			this.labelMiddleName.Name = "labelMiddleName";
			this.labelMiddleName.Size = new System.Drawing.Size(54, 13);
			this.labelMiddleName.TabIndex = 21;
			this.labelMiddleName.Text = "Отчество";
			// 
			// labelFirstName
			// 
			this.labelFirstName.AutoSize = true;
			this.labelFirstName.Location = new System.Drawing.Point(63, 52);
			this.labelFirstName.Name = "labelFirstName";
			this.labelFirstName.Size = new System.Drawing.Size(29, 13);
			this.labelFirstName.TabIndex = 20;
			this.labelFirstName.Text = "Имя";
			// 
			// labelLastName
			// 
			this.labelLastName.AutoSize = true;
			this.labelLastName.Location = new System.Drawing.Point(36, 12);
			this.labelLastName.Name = "labelLastName";
			this.labelLastName.Size = new System.Drawing.Size(56, 13);
			this.labelLastName.TabIndex = 19;
			this.labelLastName.Text = "Фамилия";
			// 
			// dateTimePickerWorkSince
			// 
			this.dateTimePickerWorkSince.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerWorkSince.Location = new System.Drawing.Point(98, 248);
			this.dateTimePickerWorkSince.Name = "dateTimePickerWorkSince";
			this.dateTimePickerWorkSince.Size = new System.Drawing.Size(245, 20);
			this.dateTimePickerWorkSince.TabIndex = 39;
			// 
			// labelWorkSince
			// 
			this.labelWorkSince.AutoSize = true;
			this.labelWorkSince.Location = new System.Drawing.Point(49, 253);
			this.labelWorkSince.Name = "labelWorkSince";
			this.labelWorkSince.Size = new System.Drawing.Size(43, 13);
			this.labelWorkSince.TabIndex = 38;
			this.labelWorkSince.Text = "Работа";
			// 
			// textBoxRate
			// 
			this.textBoxRate.Location = new System.Drawing.Point(98, 286);
			this.textBoxRate.Name = "textBoxRate";
			this.textBoxRate.Size = new System.Drawing.Size(245, 20);
			this.textBoxRate.TabIndex = 41;
			// 
			// labelRate
			// 
			this.labelRate.AutoSize = true;
			this.labelRate.Location = new System.Drawing.Point(40, 286);
			this.labelRate.Name = "labelRate";
			this.labelRate.Size = new System.Drawing.Size(55, 13);
			this.labelRate.TabIndex = 40;
			this.labelRate.Text = "Зарплата";
			// 
			// TeacherForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(707, 405);
			this.Controls.Add(this.textBoxRate);
			this.Controls.Add(this.labelRate);
			this.Controls.Add(this.dateTimePickerWorkSince);
			this.Controls.Add(this.labelWorkSince);
			this.Controls.Add(this.labelID);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonBroseNamePhoto);
			this.Controls.Add(this.pictureBoxPhoto);
			this.Controls.Add(this.textBoxPhone);
			this.Controls.Add(this.textBoxEmail);
			this.Controls.Add(this.dateTimePickerBirtDate);
			this.Controls.Add(this.textBoxMiddleName);
			this.Controls.Add(this.textBoxFirstName);
			this.Controls.Add(this.textBoxLastName);
			this.Controls.Add(this.labelPhone);
			this.Controls.Add(this.labelEmail);
			this.Controls.Add(this.labelBirthDate);
			this.Controls.Add(this.labelMiddleName);
			this.Controls.Add(this.labelFirstName);
			this.Controls.Add(this.labelLastName);
			this.Name = "TeacherForm";
			this.Text = "TeacherForm";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelID;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonBroseNamePhoto;
		private System.Windows.Forms.PictureBox pictureBoxPhoto;
		private System.Windows.Forms.TextBox textBoxPhone;
		private System.Windows.Forms.TextBox textBoxEmail;
		private System.Windows.Forms.DateTimePicker dateTimePickerBirtDate;
		private System.Windows.Forms.TextBox textBoxMiddleName;
		private System.Windows.Forms.TextBox textBoxFirstName;
		private System.Windows.Forms.TextBox textBoxLastName;
		private System.Windows.Forms.Label labelPhone;
		private System.Windows.Forms.Label labelEmail;
		private System.Windows.Forms.Label labelBirthDate;
		private System.Windows.Forms.Label labelMiddleName;
		private System.Windows.Forms.Label labelFirstName;
		private System.Windows.Forms.Label labelLastName;
		private System.Windows.Forms.DateTimePicker dateTimePickerWorkSince;
		private System.Windows.Forms.Label labelWorkSince;
		private System.Windows.Forms.TextBox textBoxRate;
		private System.Windows.Forms.Label labelRate;
	}
}