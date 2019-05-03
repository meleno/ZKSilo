using Database.Common;
using Database.IDatabase;
using System;
using Dapper;

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
			CreateDatabase(databaseConfig);
		}

		private void CreateDatabase(DatabaseConfig databaseConfig)
		{
			using (var connection = _IDbConnectionProvider.GetIDbConnectionForDatabase(databaseConfig))
			{
				connection.Open();
				connection.Execute($"CREATE DATABASE {databaseConfig.DatabaseName}");
				connection.Close();
			}
		}

		public bool MustUpdateDatabase(DatabaseConfig databaseConfig)
		{
			throw new NotImplementedException();
		}

		public void UpdateDatabase(DatabaseConfig databaseConfig)
		{
			throw new NotImplementedException();
		}
	}
}
