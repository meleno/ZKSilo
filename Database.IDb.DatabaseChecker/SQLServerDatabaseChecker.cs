using Database.Common;
using Database.IDatabase;
using System;
using System.Data.Common;

namespace Database.IDb.DatabaseChecker
{
    public class SQLServerDatabaseChecker : IDatabaseChecker
    {
        private readonly IDbConnectionFactory _iDbConnectionProvider;

        public SQLServerDatabaseChecker(IDbConnectionFactory connectionProvider)
        { _iDbConnectionProvider = connectionProvider ?? throw new ArgumentNullException(nameof(connectionProvider)); }

        public bool CheckIfDatabaseExists(DatabaseConfig databaseConfig)
        {
            try
            {
                using (var conn = _iDbConnectionProvider.GetIDbConnectionForDatabase(databaseConfig))
                { conn.Open(); }
                return true;
            }
            catch (DbException e)
            {
                if (e.ErrorCode == 4060)
                { return false; }
                else
                { throw; }
            }
        }
    }
}
