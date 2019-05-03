using Dapper;
using Database.Common;
using Database.ConnectionStringProvider;
using Database.IDatabase;
using Database.IDb.DatabaseGeneratorCluster;
using Moq;
using Moq.Dapper;
using NUnit.Framework;
using System.Data;

namespace Tests
{
	public class SQLServerDatabaseGeneratorClusterTests
	{
		SQLServerDatabaseGeneratorCluster _instance;
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
				Password = "Laurana",
				ServerPort = 12,
				UserName = "sa",
				UseSSL = false,
			};

			var connectionStringProvider = new SQLServerConnectionStringProvider();
			var connectionFactory = new Mock<IDbConnectionFactory>();
			var connection = new Mock<IDbConnection>();
			connection.SetupDapper(a => a.Execute(It.IsAny<string>(), null, null, null, null)).Returns(1);

			connectionFactory.Setup(a => a.GetIDbConnectionForDatabase(It.IsAny<DatabaseConfig>())).Returns(() => connection.Object);

			_instance = new SQLServerDatabaseGeneratorCluster(connectionFactory.Object);
		}

		[Test]
		public void GenerateDatabase()
		{
			_instance.GenerateDatabase(_config);
		}
	}
}