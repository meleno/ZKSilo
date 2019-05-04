using Dapper;
using Database.Common;
using Database.IDatabase;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Database.IDb.DatabaseGenerator
{
	public abstract class GeneralDatabaseGenerator : IDatabaseGenerator
	{
		private IDbConnectionFactory _IDbConnectionProvider;

		protected abstract string Path { get; }

		public GeneralDatabaseGenerator(IDbConnectionFactory connectionProvider)
		{
			_IDbConnectionProvider = connectionProvider;
		}

		public async Task GenerateDatabaseAsync(DatabaseConfig databaseConfig)
		{
			var scripts = GetScriptsToGenerateTheDatabase();

			using (var connection = _IDbConnectionProvider.GetIDbConnectionForDatabase(databaseConfig))
			{
				foreach (var script in scripts)
				{ await connection.ExecuteAsync(script); }
			}
		}

		protected IEnumerable<string> GetScriptsToGenerateTheDatabase()
		{
			string path = Path;
			var i = 1;
			string filename = $"{path}\\Script1.sql";

			while (File.Exists(filename))
			{
				yield return File.ReadAllText(filename);
				i++;
				filename = $"{path}\\Script{i}.sql";
			}
		}
	}
}
