using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonData
{
	[Serializable]
	[Table("Punches")]
	public class Punch
	{
		public string EmployeeId { get; set; }

		public DateTime Date { get; set; }
	}
}
