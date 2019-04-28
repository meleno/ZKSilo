using Database.Common;
using Database.IDatabase;
using System;

namespace Database.IDb.SiloDatabaseGenerator
{
	public class SiloDatabaseGeneratorFactory : IDatabaseGeneratorFactory
	{
		private IDbConnectionFactory _connectionFactory;

		public SiloDatabaseGeneratorFactory(IDbConnectionFactory connectionFactory)
		{
			_connectionFactory = connectionFactory;
		}

		public IDatabaseGenerator GetDatabaseGenerator(DatabaseConfig databaseSettings)
		{
			throw new NotImplementedException();
		}
	}
}
