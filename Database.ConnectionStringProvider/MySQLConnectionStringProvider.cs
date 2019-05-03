using Database.Common;
using Database.IDatabase;
using System;

namespace Database.ConnectionStringProvider
{
    public class MySQLConnectionStringProvider : IConnectionStringProvider
    {
        public string GetConnectionString(DatabaseConfig config)
        {
            throw new NotImplementedException();
        }
    }
}
