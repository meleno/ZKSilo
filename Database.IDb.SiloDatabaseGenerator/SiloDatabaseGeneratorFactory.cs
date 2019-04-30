using Database.Common;
using Database.IDatabase;
using Database.IDatabase.Exceptions;
using Database.IDatabase.Language;
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
			switch(databaseSettings.ServerType)
			{
				case ServerType.SQLServer:
					return new SiloDatabaseGeneratorSQLServer(_connectionFactory);
				default:
					throw new DatabaseServerNotSupportedException(string.Format(ExceptionTexts.DatabaseNotSupported, databaseSettings.ServerType));
			}
		}
	}
}
