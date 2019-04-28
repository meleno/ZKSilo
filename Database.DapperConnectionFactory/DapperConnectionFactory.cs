using Database.Common;
using Database.IDatabase;
using System.Data;
using System.Data.SqlClient;

namespace Database.DapperConnectionFactory
{
	public class DapperConnectionFactory : IDatabaseConnectionFactory
	{
		private static DapperConnectionFactory _instance;

		private DapperConnectionFactory()
		{ }

		public static IDatabaseConnectionFactory GetInstance()
		{
			_instance = _instance == null ? new DapperConnectionFactory() : _instance;
			return _instance;
		}

		public IDbConnection GetIDbConnectionForDatabase(DatabaseConfig config)
		{
			switch (config.ServerType)
			{
				case ServerType.SQLServer:
					return new SqlConnection(string.Empty);
				default:
					return new SqlConnection(string.Empty);

			}
		}
	}
}
