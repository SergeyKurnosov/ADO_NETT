namespace Academy
{
	partial class LoginForm
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
			this.labelLogin = new System.Windows.Forms.Label();
			this.labelPassword = new System.Windows.Forms.Label();
			this.textBoxLogin = new System.Windows.Forms.TextBox();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.labelServer = new System.Windows.Forms.Label();
			this.textBoxServer = new System.Windows.Forms.TextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelLogin
			// 
			this.labelLogin.AutoSize = true;
			this.labelLogin.Location = new System.Drawing.Point(30, 48);
			this.labelLogin.Name = "labelLogin";
			this.labelLogin.Size = new System.Drawing.Size(33, 13);
			this.labelLogin.TabIndex = 0;
			this.labelLogin.Text = "Login";
			this.labelLogin.Click += new System.EventHandler(this.label1_Click);
			// 
			// labelPassword
			// 
			this.labelPassword.AutoSize = true;
			this.labelPassword.Location = new System.Drawing.Point(30, 79);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(53, 13);
			this.labelPassword.TabIndex = 1;
			this.labelPassword.Text = "Password";
			// 
			// textBoxLogin
			// 
			this.textBoxLogin.Location = new System.Drawing.Point(120, 45);
			this.textBoxLogin.Name = "textBoxLogin";
			this.textBoxLogin.Size = new System.Drawing.Size(217, 20);
			this.textBoxLogin.TabIndex = 2;
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(120, 76);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(217, 20);
			this.textBoxPassword.TabIndex = 3;
			// 
			// labelServer
			// 
			this.labelServer.AutoSize = true;
			this.labelServer.Location = new System.Drawing.Point(30, 24);
			this.labelServer.Name = "labelServer";
			this.labelServer.Size = new System.Drawing.Size(38, 13);
			this.labelServer.TabIndex = 4;
			this.labelServer.Text = "Server";
			// 
			// textBoxServer
			// 
			this.textBoxServer.Location = new System.Drawing.Point(120, 17);
			this.textBoxServer.Name = "textBoxServer";
			this.textBoxServer.Size = new System.Drawing.Size(217, 20);
			this.textBoxServer.TabIndex = 5;
			this.textBoxServer.Text = "192.168.100.104";
			this.textBoxServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(141, 109);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 6;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(252, 108);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 7;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(359, 144);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.textBoxServer);
			this.Controls.Add(this.labelServer);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.textBoxLogin);
			this.Controls.Add(this.labelPassword);
			this.Controls.Add(this.labelLogin);
			this.Name = "LoginForm";
			this.Text = "LoginForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelLogin;
		private System.Windows.Forms.Label labelPassword;
		private System.Windows.Forms.TextBox textBoxLogin;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Label labelServer;
		private System.Windows.Forms.TextBox textBoxServer;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
	}
}