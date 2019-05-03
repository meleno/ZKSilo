using Database.Common;
using Database.ConnectionStringProvider;
using NUnit.Framework;

namespace Tests
{
    class MySQLConnectionStringProviderTests
    {
        MySQLConnectionStringProvider _connectionStringFactory;
        DatabaseConfig _databaseConfig;

        [SetUp]
        public void Setup()
        {
            _connectionStringFactory = new MySQLConnectionStringProvider();
            _databaseConfig = new DatabaseConfig()
            {
                AcceptAllCertificates = true,
                ConnectionType = ConnectionType.UserPassword,
                DatabaseId = 1,
                DatabaseName = "zktime",
                Password = "Laurana",
                ServerAddress = "localhost",
                ServerType = ServerType.SQLServer,
                UserName = "sa",
                UseSSL = false
            };
        }

        [Test]
        public void GetConnectionString_WhenCalled_ReturnsConnectionString()
        {
            var result = _connectionStringFactory.GetConnectionString(_databaseConfig);
            var expectedResult = $"Data Source = {_databaseConfig.ServerAddress}; Port ={_databaseConfig.ServerPort}; Database ={_databaseConfig.DatabaseName}; User ID = {_databaseConfig.UserName}; Password ={_databaseConfig.Password}; pooling = true; SslMode ={_databaseConfig.UseSSL}; connection lifetime = 300; Treat Tiny As Boolean = false; character set = utf8; AllowPublicKeyRetrieval = True; ";

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
