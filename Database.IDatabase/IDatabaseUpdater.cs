using Database.Common;

namespace Database.IDatabase
{
	public interface IDatabaseUpdater
	{
		bool MustUpdateDatabase(DatabaseConfig databaseConfig);
		void UpdateDatabase(DatabaseConfig databaseConfig);
	}
}
