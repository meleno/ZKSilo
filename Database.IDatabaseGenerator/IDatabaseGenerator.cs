namespace Database.IDatabaseGenerator
{
	public interface IDatabaseGenerator
	{
		void GenerateDatabase(DatabaseConfig databaseConfig);

		void UpdateDatabase(DatabaseConfig databaseConfig);

		bool DatabaseExists(DatabaseConfig databaseConfig);
	}
}
