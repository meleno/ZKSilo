using Database.Common;
using Database.IDatabase;
using Database.IDatabase.Exceptions;
using Database.IDatabase.Language;
using MySql.Data.MySqlClient;
using Npgsql;
using System.Data;
using System.Data.SqlClient;

namespace Database.IDb.ConnectionFactory
{
	public class ConnectionFactory : IDbConnectionFactory
	{
		private IConnectionStringProvider _connectionStringProvider;

		public ConnectionFactory(IConnectionStringProvider connectionStringProvider)
		{
			_connectionStringProvider = connectionStringProvider;
		}

		public IDbConnection GetIDbConnectionForDatabase(DatabaseConfig config)
		{
			var connectionString = _connectionStringProvider.GetDatabaseConnectionString(config);
			return GetIDBConnection(config, connectionString);
		}

		public IDbConnection GetIDbConnectionForServer(DatabaseConfig config)
		{
			var connectionString = _connectionStringProvider.GetServerConnectionString(config);
			return GetIDBConnection(config, connectionString);
		}

		private static IDbConnection GetIDBConnection(DatabaseConfig config, string connectionString)
		{
			switch (config.ServerType)
			{
				case ServerType.SQLServer:
					return new SqlConnection(connectionString);
				case ServerType.MySQL:
					return new MySqlConnection(connectionString);
				case ServerType.PostgreSQL:
					return new NpgsqlConnection(connectionString);
				default:
					throw new DatabaseServerNotSupportedException(string.Format(ExceptionTexts.DatabaseNotSupported, config.ServerType));

			}
		}
	}
}
