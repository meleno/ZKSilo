using Database.Common;
using Database.IDatabase;
using Database.IDb.ConnectionFactory;
using Database.IDb.ConnectionFactory.Exceptions;
using MySql.Data.MySqlClient;
using Npgsql;
using NUnit.Framework;
using System.Data;
using System.Data.SqlClient;

namespace Tests
{
	public class IDbConnectionFactoryTests
	{
		private IDbConnectionFactory _connectionFactoryInstance;

		[SetUp]
		public void Setup()
		{
			_connectionFactoryInstance = ConnectionFactory.GetInstance();
		}

		[Test]
		public void GetInstance_WhenCalled_ReturnsInstance()
		{
			Assert.That(_connectionFactoryInstance, Is.InstanceOf<IDbConnectionFactory>());
		}

		[Test]
		public void GetIDbConnectionForDatabase_WhenCalledWithSQLServer_ReturnsSQLServerConnection()
		{
			var result = _connectionFactoryInstance.GetIDbConnectionForDatabase(new DatabaseConfig() { ServerType = ServerType.SQLServer });
			Assert.That(result, Is.InstanceOf<SqlConnection>());
		}

		[Test]
		public void GetIDbConnectionForDatabase_WhenCalledWithMYSQL_ReturnsMySQLConnection()
		{
			var result = _connectionFactoryInstance.GetIDbConnectionForDatabase(new DatabaseConfig() { ServerType = ServerType.MySQL });
			Assert.That(result, Is.InstanceOf<MySqlConnection>());
		}

		[Test]
		public void GetIDbConnectionForDatabase_WhenCalledWithPostgreSQL_ReturnsNpgsqlConnection()
		{
			var result = _connectionFactoryInstance.GetIDbConnectionForDatabase(new DatabaseConfig() { ServerType = ServerType.PostgreSQL });
			Assert.That(result, Is.InstanceOf<NpgsqlConnection>());
		}

		[Test]
		public void GetIDbConnectionForDatabase_WhenCalledWithNotSupportedDatabase_ThrowsDatabaseNotSupportedException()
		{
			Assert.That(() => _connectionFactoryInstance.GetIDbConnectionForDatabase(new DatabaseConfig() { ServerType = ServerType.Oracle }), Throws.Exception.InstanceOf<DatabaseServerNotSupportedException>());
		}
	}
}