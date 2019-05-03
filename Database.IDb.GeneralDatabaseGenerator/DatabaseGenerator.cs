using Dapper;
using Database.Common;
using Database.IDatabase;
using System.Collections.Generic;
using System.IO;

namespace Database.IDb.GeneralDatabaseGenerator
{
	public abstract class DatabaseGenerator : IDatabaseGenerator
	{
		private IDbConnectionFactory _IDbConnectionProvider;

		protected abstract string Path { get; }

		public DatabaseGenerator(IDbConnectionFactory connectionProvider)
		{
			_IDbConnectionProvider = connectionProvider;
		}

		public void GenerateDatabase(DatabaseConfig databaseConfig)
		{
			var scripts = GetScriptsToGenerateTheDatabase();

			using (var connection = _IDbConnectionProvider.GetIDbConnectionForDatabase(databaseConfig))
			{
				foreach (var script in scripts)
				{ connection.Execute(script); }
			}
		}

		protected IEnumerable<string> GetScriptsToGenerateTheDatabase()
		{
			List<string> scripts = new List<string>();
			string path = Path;
			var i = 1;
			string filename = $"{path}\\Script1.sql";

			while (File.Exists(filename))
			{
				scripts.Add(File.ReadAllText(filename));
				i++;
				filename = $"{path}\\Script{i}.sql";
			}

			return scripts;
		}
	}
}
