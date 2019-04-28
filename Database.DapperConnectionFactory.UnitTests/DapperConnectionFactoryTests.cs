using Database.DapperConnectionFactory;
using Database.IDatabase;
using NUnit.Framework;

namespace Tests
{
	public class DapperConnectionFactoryTests
	{
		private IDatabaseConnectionFactory _connectionFactoryInstance;

		[SetUp]
		public void Setup()
		{
			_connectionFactoryInstance = DapperConnectionFactory.GetInstance();
		}

		[Test]
		public void GetInstance_WhenCalled_ReturnsInstance()
		{
			Assert.That(_connectionFactoryInstance, Is.InstanceOf<IDatabaseConnectionFactory>());
		}

		[Test]
		public void GetIDbConnectionForDatabase_WhenCalled_()
		{
			Assert.That(_connectionFactoryInstance, Is.InstanceOf<IDatabaseConnectionFactory>());
		}
	}
}