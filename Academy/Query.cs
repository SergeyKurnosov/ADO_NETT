using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Query
	{
		public string Fields { get; set; }
		public string Tables { get; set; }
		public string Condition { get; set; }
		public string GroupBy { get; set; }

		public Query(string fields, string tables, string condition="", string group_by = "") 
		{
			Fields = fields;
			Tables = tables;
			Condition = condition;
			GroupBy = group_by;
		}
	}
}
