using Database.IDatabase;
using Database.IDb.GeneralDatabaseGenerator;
using System;
using System.Collections.Generic;

namespace Database.IDb.SiloDatabaseGenerator
{
	public class SQLServerClusterDatabaseGenerator : DatabaseGenerator
	{
		public SQLServerClusterDatabaseGenerator(IDbConnectionFactory connectionProvider) : base(connectionProvider)
		{ }

		protected override IEnumerable<string> GetScriptsForGeneratingTheDatabase()
		{
			throw new NotImplementedException();
		}
	}
}
