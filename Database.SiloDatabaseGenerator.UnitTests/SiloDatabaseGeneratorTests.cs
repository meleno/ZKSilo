using Database.IDatabaseGenerator;
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
		public void DatabaseExists_WhenCalled_ReturnIfExists(DatabaseConfig databaseConfig, bool expectedResult)
		{
			//var result = _databaseGenerator.DatabaseExists()
			//Assert.That(result, Is.EqualTo(expectedResult);
		}
	}
}