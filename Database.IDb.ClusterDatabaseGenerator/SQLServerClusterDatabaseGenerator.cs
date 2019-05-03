using Database.IDatabase;
using Database.IDb.GeneralDatabaseGenerator;

namespace Database.IDb.SiloDatabaseGenerator
{
	public class SQLServerClusterDatabaseGenerator : DatabaseGenerator
	{
		public SQLServerClusterDatabaseGenerator(IDbConnectionFactory connectionProvider) : base(connectionProvider)
		{ }

		protected override string Path => $"Scripts\\Cluster\\SQLServer";
	}
}
