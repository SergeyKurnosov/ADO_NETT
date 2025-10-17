namespace Academy
{
	partial class Authorization
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
			this.labelInput = new System.Windows.Forms.Label();
			this.labellogin = new System.Windows.Forms.Label();
			this.labelPassword = new System.Windows.Forms.Label();
			this.textBoxLogin = new System.Windows.Forms.TextBox();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.buttonInput = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelInput
			// 
			this.labelInput.AutoSize = true;
			this.labelInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelInput.Location = new System.Drawing.Point(12, 9);
			this.labelInput.Name = "labelInput";
			this.labelInput.Size = new System.Drawing.Size(135, 55);
			this.labelInput.TabIndex = 0;
			this.labelInput.Text = "Вход";
			// 
			// labellogin
			// 
			this.labellogin.AutoSize = true;
			this.labellogin.Location = new System.Drawing.Point(19, 90);
			this.labellogin.Name = "labellogin";
			this.labellogin.Size = new System.Drawing.Size(29, 13);
			this.labellogin.TabIndex = 1;
			this.labellogin.Text = "login";
			// 
			// labelPassword
			// 
			this.labelPassword.AutoSize = true;
			this.labelPassword.Location = new System.Drawing.Point(19, 117);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(52, 13);
			this.labelPassword.TabIndex = 2;
			this.labelPassword.Text = "password";
			// 
			// textBoxLogin
			// 
			this.textBoxLogin.Location = new System.Drawing.Point(77, 83);
			this.textBoxLogin.Name = "textBoxLogin";
			this.textBoxLogin.Size = new System.Drawing.Size(100, 20);
			this.textBoxLogin.TabIndex = 3;
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(77, 110);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
			this.textBoxPassword.TabIndex = 4;
			// 
			// buttonInput
			// 
			this.buttonInput.Location = new System.Drawing.Point(56, 168);
			this.buttonInput.Name = "buttonInput";
			this.buttonInput.Size = new System.Drawing.Size(75, 23);
			this.buttonInput.TabIndex = 5;
			this.buttonInput.Text = "Вход";
			this.buttonInput.UseVisualStyleBackColor = true;
			this.buttonInput.Click += new System.EventHandler(this.buttonInput_Click);
			// 
			// Authorization
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(210, 203);
			this.Controls.Add(this.buttonInput);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.textBoxLogin);
			this.Controls.Add(this.labelPassword);
			this.Controls.Add(this.labellogin);
			this.Controls.Add(this.labelInput);
			this.Name = "Authorization";
			this.Text = "Authorization";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelInput;
		private System.Windows.Forms.Label labellogin;
		private System.Windows.Forms.Label labelPassword;
		private System.Windows.Forms.TextBox textBoxLogin;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Button buttonInput;
	}
}