using Database.Common;
using Database.IDatabase;

namespace Database.ConnectionStringProvider
{
	public class SQLServerConnectionStringProvider : IConnectionStringProvider
	{
		public string GetDatabaseConnectionString(DatabaseConfig config)
		{
			return $"Data Source={config.ServerAddress};Database={config.DatabaseName};User ID={config.UserName};Password={config.Password};Pooling=true;Encrypt={config.UseSSL};TrustServerCertificate={!config.AcceptAllCertificates};";
		}

		public string GetServerConnectionString(DatabaseConfig config)
		{
			return $"Data Source={config.ServerAddress};User ID={config.UserName };Password={config.Password};Pooling=true;Encrypt={config.UseSSL};TrustServerCertificate={!config.AcceptAllCertificates};";
		}
	}
}
