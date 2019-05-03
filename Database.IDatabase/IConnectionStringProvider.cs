using Database.Common;

namespace Database.IDatabase
{
	public interface IConnectionStringProvider
	{
		string GetDatabaseConnectionString(DatabaseConfig config);
		string GetServerConnectionString(DatabaseConfig config);
	}
}
