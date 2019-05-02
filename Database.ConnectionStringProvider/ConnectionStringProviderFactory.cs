using Database.Common;
using Database.IDatabase;
using Database.IDatabase.Exceptions;
using Database.IDatabase.Language;

namespace Database.ConnectionStringProvider
{
	public class ConnectionStringProviderFactory : IConnectionStringProviderFactory
	{
		public IConnectionStringProvider GetConnectionStringProvider(DatabaseConfig databaseConfig)
		{
			switch (databaseConfig.ServerType)
			{
				case ServerType.SQLServer:
					return new SQLServerConnectionStringProvider();
				default:
					throw new DatabaseServerNotSupportedException(string.Format(ExceptionTexts.DatabaseNotSupported, databaseConfig.ServerType));
			}
		}
	}
}
