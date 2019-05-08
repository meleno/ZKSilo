using Database.Common;
using Database.IDatabase;
using System;
using System.Data;

namespace Database.IDb.ConnectionFactory
{
	public abstract class ConnectionFactory : IDbConnectionFactory
	{
		private readonly IConnectionStringProvider _connectionStringProvider;

		public ConnectionFactory(IConnectionStringProvider connectionStringProvider)
		{
			_connectionStringProvider = connectionStringProvider ?? throw new ArgumentNullException(nameof(connectionStringProvider));
		}

		public IDbConnection GetIDbConnectionForDatabase(DatabaseConfig config)
		{
			var connectionString = _connectionStringProvider.GetDatabaseConnectionString(config);
			return GetIDBConnection(connectionString);
		}

		public IDbConnection GetIDbConnectionForServer(DatabaseConfig config)
		{
			var connectionString = _connectionStringProvider.GetServerConnectionString(config);
			return GetIDBConnection(connectionString);
		}

		protected abstract IDbConnection GetIDBConnection(string connectionString);
	}
}
