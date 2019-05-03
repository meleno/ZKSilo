using Database.Common;
using Database.ConnectionStringProvider;
using Database.IDb.ConnectionFactory;
using Database.IDb.SiloDatabaseGenerator;
using NUnit.Framework;

namespace Tests
{
	public class ClusterDatabaseGeneratorSQLServerTests
	{
		ClusterDatabaseGeneratorSQLServer _instance;
		DatabaseConfig _config;

		[SetUp]
		public void Setup()
		{
			_config = new DatabaseConfig()
			{
				AcceptAllCertificates = true,
				ConnectionType = ConnectionType.TrustedConnection,
				ServerAddress = @"CACHOCARNEMOVIL\SQLEXPRESS",
				DatabaseId = 1,
				DatabaseName = "test",
				Password = "none",
				ServerPort = 12,
				UserName = "asdf",
				UseSSL = false,
			};

			var connectionStringProvider = new SQLServerConnectionStringProvider();
			var connectionFactory = new SQLServerConnectionFactory(connectionStringProvider);
			_instance = new ClusterDatabaseGeneratorSQLServer(connectionFactory);
		}

		[Test]
		public void GenerateDatabase()
		{
			_instance.GenerateDatabase(_config);
		}
	}
}