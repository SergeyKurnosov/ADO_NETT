using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	 internal class Week
	{
		static readonly string[] DayNames = {"Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс"};
		 byte days;
		public Week(byte days)
		{
			this.days = days;
		}
		public override string ToString()
		{
			string learningDays = "";
			for (int i = 0; i < DayNames.Length; i++)
			{
				learningDays += (days & (1<<i)) == 0 ? "" :  $"{DayNames[i]}, ";
				//if((days & (1<<i)) != 0) learningDays += DayNames[i] + ", ";
			}

			return learningDays;
		}

	}
}
