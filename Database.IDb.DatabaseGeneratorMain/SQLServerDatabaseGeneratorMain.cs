using Database.IDatabase;
using Database.IDb.DatabaseGenerator;

namespace Database.IDb.DatabaseGeneratorMain
{
	public class SQLServerDatabaseGeneratorMain : GeneralDatabaseGenerator
	{
		public SQLServerDatabaseGeneratorMain(IDbConnectionFactory connectionProvider) : base(connectionProvider)
		{ }

		protected override string Path => $"Scripts\\Main\\SQLServer";
	}
}
