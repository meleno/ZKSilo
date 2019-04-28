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
		private const int DATABASE_NOT_EXISTS_ID = 2;
		private const int DATABASE_EXISTS_ID = 1;
		private SiloDatabaseGeneratorSQLServer _databaseGenerator;

		[SetUp]
		public void Setup()
		{
			var databaseConnectionFactory = new Mock<IDbConnectionFactory>();
			var databaseConnection = new Mock<IDbConnection>();
			var databaseConnectionException = new Mock<IDbConnection>();

			databaseConnection.Setup(dbconnection => dbconnection.Open());
			databaseConnectionException.Setup(dbConnectionException => dbConnectionException.Open()).Throws(new Exception());

			databaseConnectionFactory.Setup(dbConnFactory => dbConnFactory.GetIDbConnectionForDatabase(It.Is<DatabaseConfig>(config => config.DatabaseId == DATABASE_EXISTS_ID)))
				.Returns(() => databaseConnection.Object);

			databaseConnectionFactory.Setup(dbConnFactory => dbConnFactory.GetIDbConnectionForDatabase(It.Is<DatabaseConfig>(config => config.DatabaseId == DATABASE_NOT_EXISTS_ID)))
				.Returns(() => databaseConnectionException.Object);

			_databaseGenerator = new SiloDatabaseGeneratorSQLServer(databaseConnectionFactory.Object);
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
	}
}