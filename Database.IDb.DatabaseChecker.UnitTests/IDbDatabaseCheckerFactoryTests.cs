using Database.Common;
using Database.IDatabase;
using Database.IDatabase.Exceptions;
using Database.IDb.DatabaseChecker;
using Moq;
using NUnit.Framework;
using System.Data;

namespace Tests
{
	public class IDbDatabaseCheckerFactoryTests
	{
		private IDbDatabaseCheckerFactory _IDbDatabaseCheckerFactory;

		[SetUp]
		public void Setup()
		{
			var databaseConnectionFactory = new Mock<IDbConnectionFactory>();
			var databaseConnection = new Mock<IDbConnection>();

			databaseConnection.Setup(dbconnection => dbconnection.Open());
			databaseConnectionFactory.Setup(dbConnFactory => dbConnFactory.GetIDbConnectionForDatabase(It.IsAny<DatabaseConfig>())).Returns(() => databaseConnection.Object);

			_IDbDatabaseCheckerFactory = new IDbDatabaseCheckerFactory(databaseConnectionFactory.Object);
		}

		[Test]
		public void GetDatabaseChecker_WhenSQLServerCalled_ReturnsSQLServerDatatabaseChecker()
		{
			var sqlServerConfig = new DatabaseConfig() { ServerType = ServerType.SQLServer };
			var result = _IDbDatabaseCheckerFactory.GetDatabaseChecker(sqlServerConfig);
			Assert.That(result, Is.TypeOf<SQLServerDatabaseChecker>());
		}

		[Test]
		public void GetDatabaseChecker_WhenCalledWithSQLOracle_ThrowsDatabaseServerNotSupportedException()
		{
			Assert.That(() => _IDbDatabaseCheckerFactory.GetDatabaseChecker(new DatabaseConfig() { ServerType = ServerType.Oracle }), Throws.Exception.InstanceOf<DatabaseServerNotSupportedException>());
		}
	}
}
