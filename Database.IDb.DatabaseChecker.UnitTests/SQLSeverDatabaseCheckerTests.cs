using Database.Common;
using Database.IDatabase;
using Database.IDb.DatabaseChecker;
using Moq;
using NUnit.Framework;
using System;
using System.Data;
using System.Data.Common;

namespace Tests
{
	public class SQLException : DbException
	{
		public SQLException(string message, int errorCode) : base(message, errorCode) { }
	}

	public class SQLServerDatabaseCheckerTests
	{		
		private const int DATABASE_EXISTS_ID = 1;
		private const int DATABASE_NOT_EXISTS_ID = 2;
		private const int DATABASE_ERROR_GENERAL_ID = 3;
		private SQLServerDatabaseChecker _databaseGenerator;

		[SetUp]
		public void Setup()
		{
			var databaseConnectionFactory = new Mock<IDbConnectionFactory>();

			var databaseConnection = new Mock<IDbConnection>();
			databaseConnectionFactory.Setup(dbConnFactory => dbConnFactory.GetIDbConnectionForDatabase(It.Is<DatabaseConfig>(config => config.DatabaseId == DATABASE_EXISTS_ID))).Returns(() => databaseConnection.Object);

			var databaseNotExistsConnectionException = new Mock<IDbConnection>();
			var databaseNotExistsException = new Mock<SQLException>(new object[] { "Database not exists", 4060 });
			databaseNotExistsException.SetupGet(a => a.ErrorCode).Returns(4060);
			databaseNotExistsConnectionException.Setup(dbConnectionException => dbConnectionException.Open()).Throws(databaseNotExistsException.Object);
			databaseConnectionFactory.Setup(dbConnFactory => dbConnFactory.GetIDbConnectionForDatabase(It.Is<DatabaseConfig>(config => config.DatabaseId == DATABASE_NOT_EXISTS_ID))).Returns(() => databaseNotExistsConnectionException.Object);

			var databaseConnectionException = new Mock<IDbConnection>();		
			var generalException = new Mock<Exception>();
			databaseConnectionException.Setup(dbException => dbException.Open()).Throws(generalException.Object);			
			databaseConnectionFactory.Setup(dbConnFactory => dbConnFactory.GetIDbConnectionForDatabase(It.Is<DatabaseConfig>(config => config.DatabaseId == DATABASE_ERROR_GENERAL_ID))).Returns(() => databaseConnectionException.Object);

			_databaseGenerator = new SQLServerDatabaseChecker(databaseConnectionFactory.Object);
		}

		[Test]
		public void DatabaseExists_WhenDatabaseExists_ReturnTrue()
		{
			var databaseConfig = new DatabaseConfig() { DatabaseId = DATABASE_EXISTS_ID };
			var result = _databaseGenerator.CheckIfDatabaseExists(databaseConfig);
			Assert.That(result, Is.EqualTo(true));
		}

		[Test]
		public void DatabaseExists_WhenDatabaseNotExists_ReturnFalse()
		{
			var databaseConfig = new DatabaseConfig() { DatabaseId = DATABASE_NOT_EXISTS_ID };
			var result = _databaseGenerator.CheckIfDatabaseExists(databaseConfig);
			Assert.That(result, Is.EqualTo(false));
		}

		[Test]
		public void DatabaseExists_WhenConnectionFails_ThrowsException()
		{
			var databaseConfig = new DatabaseConfig() { DatabaseId = DATABASE_ERROR_GENERAL_ID };
			Assert.That(() => _databaseGenerator.CheckIfDatabaseExists(databaseConfig), Throws.InstanceOf<Exception>());
		}
	}
}