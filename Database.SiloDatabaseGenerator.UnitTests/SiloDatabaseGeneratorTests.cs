using Database.Common;
using Database.SiloDatabaseGenerator;
using NUnit.Framework;

namespace Tests
{
	public class SiloDatabaseGeneratorTests
	{
		private SiloDatabaseGenerator _databaseGenerator;

		[SetUp]
		public void Setup()
		{
			_databaseGenerator = new SiloDatabaseGenerator();
		}

		[Test]
		public void DatabaseExists_WhenDatabaseNotExists_ReturnFalse()
		{
			var databaseConfig = new DatabaseConfig();
			var result = _databaseGenerator.CheckIfDatabaseExists(databaseConfig);
			Assert.That(result, Is.EqualTo(false));
		}
	}
}