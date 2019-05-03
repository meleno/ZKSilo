using Database.IDatabase;
using System.Data;
using System.Data.SqlClient;

namespace Database.IDb.ConnectionFactory
{
	public class SQLServerConnectionFactory : ConnectionFactory
	{
		public SQLServerConnectionFactory(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
		{ }

		protected override IDbConnection GetIDBConnection(string connectionString)
		{
			return new SqlConnection(connectionString);
		}
	}
}
