using Database.Common;

namespace Database.IDatabase
{
	public interface IDatabaseGeneratorFactory
	{
		IDatabaseGenerator GetDatabaseGenerator(DatabaseConfig databaseSettings);
	}
}
