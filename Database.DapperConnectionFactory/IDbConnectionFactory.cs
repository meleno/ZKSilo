using Database.Common;
using Database.IDatabase;
using System.Data;
using System.Data.SqlClient;

namespace Database.IDbConnectionFactory
{
	public class IDbConnectionFactory : IDatabaseConnectionFactory
	{
		private static IDbConnectionFactory _instance;

		private IDbConnectionFactory()
		{ }

		public static IDatabaseConnectionFactory GetInstance()
		{
			_instance = _instance == null ? new IDbConnectionFactory() : _instance;
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
