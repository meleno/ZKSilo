using Database.IDatabase;
using Database.IDb.DatabaseGenerator;

namespace Database.IDb.DatabaseGeneratorCluster
{
	public class SQLServerDatabaseGeneratorCluster : GeneralDatabaseGenerator
	{
		public SQLServerDatabaseGeneratorCluster(IDbConnectionFactory connectionProvider) : base(connectionProvider)
		{ }

		protected override string Path => $"Scripts\\Cluster\\SQLServer";
	}
}
