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
		private static ConnectionFactory _instance;

		private ConnectionFactory()
		{ }

		public static IDbConnectionFactory GetInstance()
		{
			_instance = _instance == null ? new ConnectionFactory() : _instance;
			return _instance;
		}

		public IDbConnection GetIDbConnectionForDatabase(DatabaseConfig config)
		{
			switch (config.ServerType)
			{
				case ServerType.SQLServer:
					return new SqlConnection(string.Empty);
				case ServerType.MySQL:
					return new MySqlConnection(string.Empty);
				case ServerType.PostgreSQL:
					return new NpgsqlConnection(string.Empty);
				default:
					throw new DatabaseServerNotSupportedException(string.Format(ExceptionTexts.DatabaseNotSupported, config.ServerType));

			}
		}
	}
}
