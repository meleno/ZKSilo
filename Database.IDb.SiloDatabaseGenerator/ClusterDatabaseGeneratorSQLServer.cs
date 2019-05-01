using Database.Common;
using Database.IDatabase;
using System;

namespace Database.IDb.SiloDatabaseGenerator
{
	public class ClusterDatabaseGeneratorSQLServer : IDatabaseGenerator, IDatabaseUpdater
	{
		private IDbConnectionFactory _IDbConnectionProvider;

		public ClusterDatabaseGeneratorSQLServer(IDbConnectionFactory connectionProvider)
		{
			_IDbConnectionProvider = connectionProvider;
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
