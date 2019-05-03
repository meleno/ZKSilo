using Database.IDatabase;
using Database.IDb.GeneralDatabaseGenerator;
using System;
using System.Collections.Generic;
using System.IO;

namespace Database.IDb.SiloDatabaseGenerator
{
	public class SQLServerClusterDatabaseGenerator : DatabaseGenerator
	{
		public SQLServerClusterDatabaseGenerator(IDbConnectionFactory connectionProvider) : base(connectionProvider)
		{ }

		protected override IEnumerable<string> GetScriptsToGenerateTheDatabase()
		{
			List<string> scripts = new List<string>();
			string path = $"Scripts\\Cluster\\SQLServer";
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
