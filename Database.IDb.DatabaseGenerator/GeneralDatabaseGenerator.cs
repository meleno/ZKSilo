using Dapper;
using Database.Common;
using Database.IDatabase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Database.IDb.DatabaseGenerator
{
	public abstract class GeneralDatabaseGenerator : IDatabaseGenerator
	{
		protected IDbConnectionFactory _IDbConnectionProvider;

		protected abstract string Path { get; }

		public GeneralDatabaseGenerator(IDbConnectionFactory connectionProvider)
		{
			_IDbConnectionProvider = connectionProvider ?? throw new ArgumentNullException(nameof(connectionProvider));
		}

		public async Task GenerateDatabaseAsync(DatabaseConfig databaseConfig)
		{
			await CreateDatabase(databaseConfig);
			await ExecuteScripts(databaseConfig);
		}

		protected abstract Task CreateDatabase(DatabaseConfig databaseConfig);

		private async Task ExecuteScripts(DatabaseConfig databaseConfig)
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
			var i = 1;
			string filename = $"{Path}\\Script1.sql";

			while (File.Exists(filename))
			{
				yield return File.ReadAllText(filename);
				i++;
				filename = $"{Path}\\Script{i}.sql";
			}
		}
	}
}
