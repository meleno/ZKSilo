using Database.Common;
using Database.IDatabase;
using Database.IDatabase.Exceptions;
using Database.IDb.ConnectionFactory;
using Moq;
using MySql.Data.MySqlClient;
using Npgsql;
using NUnit.Framework;
using System.Data.SqlClient;

namespace Tests
{
	public class IDbConnectionFactoryTests
	{
		private IDbConnectionFactory _connectionFactoryInstance;

		[SetUp]
		public void Setup()
		{
			var connectionStringProvider = new Mock<IConnectionStringProvider>();
			_connectionFactoryInstance = new ConnectionFactory(connectionStringProvider.Object);
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

		[Test]
		public void GetIDbConnectionForServer_WhenCalledWithSQLServer_ReturnsSQLServerConnection()
		{
			var result = _connectionFactoryInstance.GetIDbConnectionForServer(new DatabaseConfig() { ServerType = ServerType.SQLServer });
			Assert.That(result, Is.InstanceOf<SqlConnection>());
		}

		[Test]
		public void GetIDbConnectionForServer_WhenCalledWithMYSQL_ReturnsMySQLConnection()
		{
			var result = _connectionFactoryInstance.GetIDbConnectionForServer(new DatabaseConfig() { ServerType = ServerType.MySQL });
			Assert.That(result, Is.InstanceOf<MySqlConnection>());
		}

		[Test]
		public void GetIDbConnectionForServer_WhenCalledWithPostgreSQL_ReturnsNpgsqlConnection()
		{
			var result = _connectionFactoryInstance.GetIDbConnectionForServer(new DatabaseConfig() { ServerType = ServerType.PostgreSQL });
			Assert.That(result, Is.InstanceOf<NpgsqlConnection>());
		}

		[Test]
		public void GetIDbConnectionForServer_WhenCalledWithNotSupportedDatabase_ThrowsDatabaseNotSupportedException()
		{
			Assert.That(() => _connectionFactoryInstance.GetIDbConnectionForServer(new DatabaseConfig() { ServerType = ServerType.Oracle }), Throws.Exception.InstanceOf<DatabaseServerNotSupportedException>());
		}
	}
}