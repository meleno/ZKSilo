using Database.Common;
using Database.IDatabase;

namespace Database.ConnectionStringProvider
{
	public class SQLServerConnectionStringProvider : IConnectionStringProvider
	{
		public string GetConnectionString(DatabaseConfig config)
		{
			return $"Data Source={config.ServerAddress};Database={config.DatabaseName};User ID={config.UserName};Password={config.Password};Pooling=true;Encrypt={config.UseSSL};TrustServerCertificate={!config.AcceptAllCertificates};";
		}
	}
}
