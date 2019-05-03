using Database.IDatabase;
using Database.IDb.GeneralDatabaseGenerator;
using System;
using System.Collections.Generic;

namespace Database.IDb.SiloDatabaseGenerator
{
	public class ClusterDatabaseGeneratorSQLServer : DatabaseGenerator
	{
		public ClusterDatabaseGeneratorSQLServer(IDbConnectionFactory connectionProvider) : base(connectionProvider)
		{ }

		protected override IEnumerable<string> GetScriptsForGeneratingTheDatabase()
		{
			throw new NotImplementedException();
		}
	}
}
