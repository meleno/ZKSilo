using Database.Common;
using Database.IDatabase;
using Database.IDb.ConnectionFactory;
using Moq;
using NUnit.Framework;
using System.Data.SqlClient;

namespace Tests
{
	public class SQLServerConnectionFactoryTests
	{
		private IDbConnectionFactory _connectionFactoryInstance;

		[SetUp]
		public void Setup()
		{
			var connectionStringProvider = new Mock<IConnectionStringProvider>();
			_connectionFactoryInstance = new SQLServerConnectionFactory(connectionStringProvider.Object);
		}

		[Test]
		public void GetIDbConnectionForDatabase_WhenCalledWithSQLServer_ReturnsSQLServerConnection()
		{
			var result = _connectionFactoryInstance.GetIDbConnectionForDatabase(new DatabaseConfig());
			Assert.That(result, Is.InstanceOf<SqlConnection>());
		}
	}
}