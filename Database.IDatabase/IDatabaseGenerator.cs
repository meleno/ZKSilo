using Database.Common;
using System.Threading.Tasks;

namespace Database.IDatabase
{
	public interface IDatabaseGenerator
	{
		Task GenerateDatabaseAsync(DatabaseConfig databaseConfig);
	}
}
