using Database.Common;
using Database.IDatabase;
using Database.IDb.SiloDatabaseGenerator;
using Moq;
using NUnit.Framework;
using System;
using System.Data;

namespace Tests
{
	public class SiloDatabaseGeneratorTests
	{
		private SiloDatabaseGeneratorSQLServer _databaseGenerator;

		[SetUp]
		public void Setup()
		{
			var databaseConnectionFactory = new Mock<IDbConnectionFactory>();
			var databaseConnection = new Mock<IDbConnection>();
			var databaseConnectionException = new Mock<IDbConnection>();

			databaseConnection.Setup(dbconnection => dbconnection.Open());
			databaseConnectionException.Setup(dbConnectionException => dbConnectionException.Open()).Throws(new Exception());

			databaseConnectionFactory.Setup(dbConnFactory => dbConnFactory.GetIDbConnectionForDatabase(It.Is<DatabaseConfig>(config => config.DatabaseId == 1)))
				.Returns(() => databaseConnection.Object);

			databaseConnectionFactory.Setup(dbConnFactory => dbConnFactory.GetIDbConnectionForDatabase(It.Is<DatabaseConfig>(config => config.DatabaseId == 2)))
				.Returns(() => databaseConnectionException.Object);

			_databaseGenerator = new SiloDatabaseGeneratorSQLServer(databaseConnectionFactory.Object);
		}

		[Test]
		public void DatabaseExists_WhenDatabaseExists_ReturnTrue()
		{
			var databaseConfig = new DatabaseConfig() { DatabaseId = 1 };
			var result = _databaseGenerator.CheckIfDatabaseExists(databaseConfig);
			Assert.That(result, Is.EqualTo(true));
		}

		[Test]
		public void DatabaseExists_WhenDatabaseNotExists_ReturnFalse()
		{
			var databaseConfig = new DatabaseConfig() { DatabaseId = 2 };
			var result = _databaseGenerator.CheckIfDatabaseExists(databaseConfig);
			Assert.That(result, Is.EqualTo(false));
		}
	}
}