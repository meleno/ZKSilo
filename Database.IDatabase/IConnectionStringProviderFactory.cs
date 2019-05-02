using Database.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.IDatabase
{
	public interface IConnectionStringProviderFactory
	{
		IConnectionStringProvider GetConnectionStringProvider(DatabaseConfig databaseConfig);
	}
}
