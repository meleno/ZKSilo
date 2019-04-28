using Database.Common;
using Database.IDatabase;
using System.Data;
using System.Data.SqlClient;

namespace Database.DapperConnectionFactory
{
	public class DapperConnectionFactory : IDatabaseConnectionFactory
	{
		public IDbConnection GetIDbConnectionForDatabase(DatabaseConfig config)
		{
			return new SqlConnection(string.Empty);
		}
	}
}
