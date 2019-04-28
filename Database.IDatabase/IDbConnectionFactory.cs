using Database.Common;
using System.Data;

namespace Database.IDatabase
{
	public interface IDbConnectionFactory
	{
		IDbConnection GetIDbConnectionForDatabase(DatabaseConfig config);
	}
}
