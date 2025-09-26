using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{



			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());

			//// Создаём новую форму
			//Form myForm = new Form();
			//myForm.Text = "Моя программно созданная форма";
			//myForm.Width = 400;
			//myForm.Height = 300;

			//// Создаём кнопку
			//Button button = new Button();
			//button.Text = "Нажми меня";
			//button.Left = 300;
			//button.Top = 10;
			//button.Width = 100;
			//button.Height = 20;

			//// Добавляем обработчик события клика
			//button.Click += (sender, e) =>
			//{
			//	MessageBox.Show("Кнопка нажата!");
			//	myForm.Close();
			//};

			//// Добавляем кнопку на форму
			//myForm.Controls.Add(button);

			//// Запускаем приложение с этой формой

			//myForm.ShowDialog();
			



		}
	}
}
