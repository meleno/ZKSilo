using Database.Common;
using Database.IDatabase;
using System.Data.Common;
using System.Data.SqlClient;

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
			catch (DbException e)
			{
				if (e.ErrorCode == 4060)
				{ return false; }
				else
				{ throw; }
			}
		}
	}
}
