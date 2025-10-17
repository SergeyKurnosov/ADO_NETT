using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			AllocConsole();


			int[] arr = { 3, 5, 8, 13, 21, 34, 55 };

			IEnumerable<int> FibonacciQuery =
				from i in arr
				where i > 20
				orderby i descending
				select i;

			foreach(int i in FibonacciQuery)
			{
				Console.Write($"{i}\t");
			}
			Console.WriteLine();

			/////////////////////////////
			//Immidiate queries
			Console.WriteLine((from i in arr select i).Count());
			Console.WriteLine((from i in arr select i).Sum());
			List<int> list = (from i in arr select i).ToList();


		}

		[DllImport("kernel32.dll")]
		public static extern bool AllocConsole();
		[DllImport("kernel32.dll")]                   
		public static extern bool FreeConsole();
	}





}
