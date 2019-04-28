using Database.Common;

namespace Database.IDatabase
{
	public interface IDatabaseGenerator
	{
		void GenerateDatabase(DatabaseConfig databaseConfig);
	}
}
