using Database.IDatabase;
using Database.IDb.DatabaseGenerator;

namespace Database.IDb.DatabaseGeneratorNLog
{
	public class SQLServerDatabaseGeneratorNLog : GeneralDatabaseGenerator
	{
		public SQLServerDatabaseGeneratorNLog(IDbConnectionFactory connectionProvider) : base(connectionProvider)
		{ }

		protected override string Path => $"Scripts\\NLog\\SQLServer";
	}
}
