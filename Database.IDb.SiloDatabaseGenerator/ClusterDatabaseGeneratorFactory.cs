using Database.Common;
using Database.IDatabase;
using Database.IDatabase.Exceptions;
using Database.IDatabase.Language;
using System;

namespace Database.IDb.SiloDatabaseGenerator
{
	public class ClusterDatabaseGeneratorFactory : IDatabaseGeneratorFactory
	{
		private IDbConnectionFactory _connectionFactory;

		public ClusterDatabaseGeneratorFactory(IDbConnectionFactory connectionFactory)
		{
			_connectionFactory = connectionFactory;
		}

		public IDatabaseGenerator GetDatabaseGenerator(DatabaseConfig databaseSettings)
		{
			switch(databaseSettings.ServerType)
			{
				case ServerType.SQLServer:
					return new ClusterDatabaseGeneratorSQLServer(_connectionFactory);
				default:
					throw new DatabaseServerNotSupportedException(string.Format(ExceptionTexts.DatabaseNotSupported, databaseSettings.ServerType));
			}
		}
	}
}
