using Database.Common;
using Database.IDatabase;
using System;

namespace Database.SiloDatabaseGenerator
{
	public class SiloDatabaseGenerator : IDatabaseGenerator, IDatabaseChecker, IDatabaseUpdater
	{
		private IDatabaseConnectionFactory _IDbConnectionProvider;

		public SiloDatabaseGenerator(IDatabaseConnectionFactory connectionProvider)
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
