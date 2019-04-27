using Database.Common;

namespace Database.IDatabase
{
	public interface IDatabaseUpdater
	{
		void UpdateDatabase(DatabaseConfig databaseConfig);
	}
}
