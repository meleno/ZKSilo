using Database.Common;

namespace Database.IDatabase
{
	public interface IConnectionStringProvider
	{
		string GetConnectionString(DatabaseConfig config);
	}
}
