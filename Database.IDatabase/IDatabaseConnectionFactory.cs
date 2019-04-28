using Database.Common;
using System.Data;

namespace Database.IDatabase
{
	public interface IDatabaseConnectionFactory
	{
		IDbConnection GetIDbConnectionForDatabase(DatabaseConfig config);
	}
}
