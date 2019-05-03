using Database.Common;
using Database.ConnectionStringProvider;
using Database.IDatabase.Exceptions;
using NUnit.Framework;

namespace Tests
{
	public class ConnectionStringProviderFactoryTests
	{
		private ConnectionStringProviderFactory _connectionStringProviderFactory;

		[SetUp]
		public void Setup()
		{
			_connectionStringProviderFactory = new ConnectionStringProviderFactory();
		}

		[Test]
		public void GetConnectionStringProvider_WhenSQLServerCalled_ReturnsSQLServerConnectionStringProvider()
		{
			var sqlServerConfig = new DatabaseConfig() { ServerType = ServerType.SQLServer };
			var result = _connectionStringProviderFactory.GetConnectionStringProvider(sqlServerConfig);
			Assert.That(result, Is.TypeOf<SQLServerConnectionStringProvider>());
		}

		[Test]
		public void GetConnectionStringProvider_WhenCalledWithSQLOracle_ThrowsDatabaseServerNotSupportedException()
		{
			Assert.That(() => _connectionStringProviderFactory.GetConnectionStringProvider(new DatabaseConfig() { ServerType = ServerType.Oracle }), Throws.Exception.InstanceOf<DatabaseServerNotSupportedException>());
		}
	}
}
