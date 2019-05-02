using Database.Common;
using Database.IDatabase;
using Database.IDatabase.Exceptions;
using Database.IDatabase.Language;

namespace Database.IDb.DatabaseChecker
{
	public class IDbDatabaseCheckerFactory : IDatabaseCheckerFactory
	{
		private IDbConnectionFactory _connectionFactory;

		public IDbDatabaseCheckerFactory(IDbConnectionFactory connectionFactory)
		{
			_connectionFactory = connectionFactory;
		}

		public IDatabaseChecker GetDatabaseChecker(DatabaseConfig databaseConfig)
		{
			switch (databaseConfig.ServerType)
			{
				case ServerType.SQLServer:
					return new SQLServerDatabaseChecker(_connectionFactory);
				default:
					throw new DatabaseServerNotSupportedException(string.Format(ExceptionTexts.DatabaseNotSupported, databaseConfig.ServerType));
			}
		}
	}
}
