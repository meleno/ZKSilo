using Database.Common;
using System.Data;

namespace Database.IDbConnectionFactory
{
	public interface IDatabaseConnectionFactory
	{
		IDbConnection GetIDbConnectionForDatabase(DatabaseConfig config);
	}
}
