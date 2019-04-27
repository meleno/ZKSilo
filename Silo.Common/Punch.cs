using Dapper.Contrib.Extensions;
using System;

namespace Silo.Common
{
	[Serializable]
	[Table("Punches")]
	public class Punch
	{
		public string EmployeeId { get; set; }

		public DateTime Date { get; set; }
	}
}
