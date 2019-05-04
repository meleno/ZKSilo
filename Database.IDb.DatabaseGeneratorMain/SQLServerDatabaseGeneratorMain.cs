using Dapper;
using Database.Common;
using Database.IDatabase;
using Database.IDb.DatabaseGenerator;
using System.Threading.Tasks;

namespace Database.IDb.DatabaseGeneratorMain
{
	public class SQLServerDatabaseGeneratorMain : GeneralDatabaseGenerator
	{
		public SQLServerDatabaseGeneratorMain(IDbConnectionFactory connectionProvider) : base(connectionProvider)
		{ }

		protected override string Path => $"Scripts\\Main\\SQLServer";

		protected override async Task CreateDatabase(DatabaseConfig databaseConfig)
		{
			using (var connection = _IDbConnectionProvider.GetIDbConnectionForServer(databaseConfig))
			{
				await connection.ExecuteAsync($"CREATE DATABASE {databaseConfig.DatabaseName}");
			}
		}
	}
}
