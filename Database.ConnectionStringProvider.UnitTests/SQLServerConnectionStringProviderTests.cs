using Database.Common;
using Database.ConnectionStringProvider;
using NUnit.Framework;

namespace Tests
{
	public class SQLServerConnectionStringProviderTests
	{
		SQLServerConnectionStringProvider _connectionStringFactory;
		DatabaseConfig _SQLServerdatabaseConfig;

		[SetUp]
		public void Setup()
		{
			_connectionStringFactory = new SQLServerConnectionStringProvider();
			_SQLServerdatabaseConfig = new DatabaseConfig() {
				AcceptAllCertificates = true,
				ConnectionType = ConnectionType.UserPassword,
				DatabaseId = 1,
				DatabaseName = "zktime",
				Password = "Laurana",
				ServerAddress = "localhost",
				UserName = "sa",
				UseSSL = false };
		}

		[Test]
		public void GetDatabaseConnectionString_WhenCalled_ReturnsConnectionString()
		{
			var result = _connectionStringFactory.GetDatabaseConnectionString(_SQLServerdatabaseConfig);
			var expectedResult = $"Data Source={_SQLServerdatabaseConfig.ServerAddress};Database={_SQLServerdatabaseConfig.DatabaseName};User ID={_SQLServerdatabaseConfig.UserName };Password={_SQLServerdatabaseConfig.Password};Pooling=true;Encrypt={_SQLServerdatabaseConfig.UseSSL};TrustServerCertificate={!_SQLServerdatabaseConfig.AcceptAllCertificates};";

			Assert.That(result, Is.EqualTo(expectedResult));
		}

		[Test]
		public void GetServerConnectionString_WhenCalled_ReturnsConnectionString()
		{
			var result = _connectionStringFactory.GetServerConnectionString(_SQLServerdatabaseConfig);
			var expectedResult = $"Data Source={_SQLServerdatabaseConfig.ServerAddress};User ID={_SQLServerdatabaseConfig.UserName };Password={_SQLServerdatabaseConfig.Password};Pooling=true;Encrypt={_SQLServerdatabaseConfig.UseSSL};TrustServerCertificate={!_SQLServerdatabaseConfig.AcceptAllCertificates};";

			Assert.That(result, Is.EqualTo(expectedResult));
		}
	}
}