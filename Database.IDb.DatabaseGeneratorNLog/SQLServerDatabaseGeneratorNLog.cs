using Dapper;
using Database.Common;
using Database.IDatabase;
using Database.IDb.DatabaseGenerator;
using System.Threading.Tasks;

namespace Database.IDb.DatabaseGeneratorNLog
{
	public class SQLServerDatabaseGeneratorNLog : GeneralDatabaseGenerator
	{
		public SQLServerDatabaseGeneratorNLog(IDbConnectionFactory connectionProvider) : base(connectionProvider)
		{ }

		protected override string Path => $"Scripts\\NLog\\SQLServer";

		protected override async Task CreateDatabase(DatabaseConfig databaseConfig)
		{
			using (var connection = _IDbConnectionProvider.GetIDbConnectionForServer(databaseConfig))
			{
				await connection.ExecuteAsync($"CREATE DATABASE {databaseConfig.DatabaseName}");
			}
		}
	}
}
