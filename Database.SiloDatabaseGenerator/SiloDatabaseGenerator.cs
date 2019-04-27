using Database.Common;
using System;
using Database.IDatabase;

namespace Database.SiloDatabaseGenerator
{
	public class SiloDatabaseGenerator : IDatabaseGenerator, IDatabaseChecker, IDatabaseUpdater
	{
		public bool CheckIfDatabaseExists(DatabaseConfig databaseConfig)
		{
			throw new NotImplementedException();
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
