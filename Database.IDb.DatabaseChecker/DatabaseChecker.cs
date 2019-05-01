using Database.Common;
using Database.IDatabase;

namespace Database.IDb.DatabaseChecker
{
	public class DatabaseChecker : IDatabaseChecker
	{
		private IDbConnectionFactory _IDbConnectionProvider;

		public DatabaseChecker(IDbConnectionFactory connectionProvider)
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
