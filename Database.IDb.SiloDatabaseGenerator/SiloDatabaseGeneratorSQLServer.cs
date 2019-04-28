using Database.Common;
using Database.IDatabase;
using System;

namespace Database.IDb.SiloDatabaseGenerator
{
	public class SiloDatabaseGeneratorSQLServer : IDatabaseGenerator, IDatabaseChecker, IDatabaseUpdater
	{
		private IDbConnectionFactory _IDbConnectionProvider;

		public SiloDatabaseGeneratorSQLServer(IDbConnectionFactory connectionProvider)
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

		public void GenerateDatabase(DatabaseConfig databaseConfig)
		{
			throw new NotImplementedException();
		}

		public void UpdateDatabase(DatabaseConfig databaseConfig)
		{
			throw new NotImplementedException();
		}
	}
}
