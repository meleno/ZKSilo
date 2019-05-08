using Database.Common;

namespace Database.IDatabase
{
	public interface IDatabaseChecker
	{
		bool CheckIfDatabaseExists(DatabaseConfig databaseConfig);
	}
}
