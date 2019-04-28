using Database.Common;
using Database.IDatabase;
using Database.IDb.SiloDatabaseGenerator;
using Moq;
using NUnit.Framework;
using System.Data;

namespace Tests
{
	public class SiloDatabaseGeneratorTests
	{
		private SiloDatabaseGenerator _databaseGenerator;

		[SetUp]
		public void Setup()
		{
			var databaseConnectionFactory = new Mock<IDbConnectionFactory>();
			var databaseConnection = new Mock<IDbConnection>();

			databaseConnectionFactory.Setup(dbConnFactory => dbConnFactory.GetIDbConnectionForDatabase(It.IsAny<DatabaseConfig>()))
				.Returns(() => databaseConnection.Object);

			_databaseGenerator = new SiloDatabaseGenerator(databaseConnectionFactory.Object);
		}

		[Test]
		public void DatabaseExists_WhenDatabaseNotExists_ReturnFalse()
		{
			var databaseConfig = new DatabaseConfig() { DatabaseId = 1 };
			var result = _databaseGenerator.CheckIfDatabaseExists(databaseConfig);
			Assert.That(result, Is.EqualTo(false));
		}

		[Test]
		public void DatabaseExists_WhenDatabaseExists_ReturnTrue()
		{
			var databaseConfig = new DatabaseConfig() { DatabaseId = 2 };
			var result = _databaseGenerator.CheckIfDatabaseExists(databaseConfig);
			Assert.That(result, Is.EqualTo(true));
		}
	}
}