﻿using Dapper;
using Database.Common;
using Database.IDatabase;
using System.Collections.Generic;

namespace Database.IDb.GeneralDatabaseGenerator
{
	public abstract class DatabaseGenerator : IDatabaseGenerator
	{
		private IDbConnectionFactory _IDbConnectionProvider;

		public DatabaseGenerator(IDbConnectionFactory connectionProvider)
		{
			_IDbConnectionProvider = connectionProvider;
		}

		public void GenerateDatabase(DatabaseConfig databaseConfig)
		{
			var scripts = GetScriptsForGeneratingTheDatabase();

			using (var connection = _IDbConnectionProvider.GetIDbConnectionForServer(databaseConfig))
			{
				foreach (var script in scripts)
				{ connection.Execute(script); }
			}
		}

		protected abstract IEnumerable<string> GetScriptsForGeneratingTheDatabase();
	}
}
