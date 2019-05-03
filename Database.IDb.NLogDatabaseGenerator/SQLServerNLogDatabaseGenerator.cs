using Database.IDatabase;
using Database.IDb.GeneralDatabaseGenerator;

namespace Database.IDb.NLogDatabaseGenerator
{
	public class SQLServerNLogDatabaseGenerator : DatabaseGenerator
	{
		public SQLServerNLogDatabaseGenerator(IDbConnectionFactory connectionProvider) : base(connectionProvider)
		{ }

		protected override string Path => $"Scripts\\NLog\\SQLServer";
	}
}
