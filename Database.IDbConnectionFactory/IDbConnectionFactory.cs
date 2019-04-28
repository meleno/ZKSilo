using Database.Common;
using Database.IDatabase;
using Database.IDbConnectionFactory.Exceptions;
using Database.IDbConnectionFactory.Language;
using MySql.Data.MySqlClient;
using Npgsql;
using System.Data;
using System.Data.SqlClient;

namespace Database.IDbConnectionFactory
{
	public class IDbConnectionFactory : IDatabaseConnectionFactory
	{
		private static IDbConnectionFactory _instance;

		private IDbConnectionFactory()
		{ }

		public static IDatabaseConnectionFactory GetInstance()
		{
			_instance = _instance == null ? new IDbConnectionFactory() : _instance;
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
					throw new DatabaseServerNotSupportedException(string.Format(ExceptionTexts.DatabaseNotSupported, config.ServerType), null, 1000);

			}
		}
	}
}
