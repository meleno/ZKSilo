using Database.Common;

namespace Database.IDatabase
{
	public interface IDatabaseCheckerFactory
	{
		IDatabaseChecker GetDatabaseChecker(DatabaseConfig databaseConfig);
	}
}
