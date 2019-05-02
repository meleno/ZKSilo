using Database.Common;
using Database.IDatabase;

namespace Database.IDb.DatabaseChecker
{
	public class SQLServerDatabaseChecker : IDatabaseChecker
	{
		private IDbConnectionFactory _IDbConnectionProvider;

		public SQLServerDatabaseChecker(IDbConnectionFactory connectionProvider)
		{
			_IDbConnectionProvider = connectionProvider;
		}

		public bool CheckIfDatabaseExists(DatabaseConfig databaseConfig)
		{
			try
			{
				using (var conn = _IDbConnectionProvider.GetIDbConnectionForDatabase(databaseConfig))
				{ conn.Open(); }
				return true;
			}
			catch
			{ return false; }
		}
	}
}
