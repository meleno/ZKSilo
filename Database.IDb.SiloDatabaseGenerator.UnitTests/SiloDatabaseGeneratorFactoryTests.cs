using Database.Common;
using Database.IDatabase;
using Database.IDatabase.Exceptions;
using Database.IDb.SiloDatabaseGenerator;
using Moq;
using NUnit.Framework;
using System.Data;


namespace Tests
{
	class SiloDatabaseGeneratorFactoryTests
	{
		IDatabaseGeneratorFactory _databaseGenerator;

		[SetUp]
		public void Setup()
		{
			var databaseConnectionFactory = new Mock<IDbConnectionFactory>();
			var databaseConnection = new Mock<IDbConnection>();

			databaseConnectionFactory.Setup(dbConnFactory => dbConnFactory.GetIDbConnectionForDatabase(It.IsAny<DatabaseConfig>())).Returns(() => databaseConnection.Object);

			_databaseGenerator = new SiloDatabaseGeneratorFactory(databaseConnectionFactory.Object);
		}

		[Test]
		public void GetDatabaseGenerator_WhenCalledWithSQLServer_ReturnsSQLServerGenerator()
		{
			var result = _databaseGenerator.GetDatabaseGenerator(new DatabaseConfig() { ServerType = ServerType.SQLServer });
			Assert.That(result, Is.TypeOf<SiloDatabaseGeneratorSQLServer>());
		}

		[Test]
		public void GetDatabaseGenerator_WhenCalledWithSQLOracle_ThrowsDatabaseServerNotSupportedException()
		{
			Assert.That(() => _databaseGenerator.GetDatabaseGenerator(new DatabaseConfig() { ServerType = ServerType.Oracle }), Throws.Exception.InstanceOf<DatabaseServerNotSupportedException>());
		}
	}
}
