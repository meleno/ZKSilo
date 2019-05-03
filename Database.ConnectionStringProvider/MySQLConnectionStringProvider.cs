using Database.Common;
using Database.IDatabase;
using System;

namespace Database.ConnectionStringProvider
{
    public class MySQLConnectionStringProvider : IConnectionStringProvider
    {
        public string GetConnectionString(DatabaseConfig config)
        {
            return $"Data Source = {config.ServerAddress}; Port ={config.ServerPort}; Database ={config.DatabaseName}; User ID = {config.UserName}; Password ={config.Password}; pooling = true; SslMode ={config.UseSSL}; connection lifetime = 300; Treat Tiny As Boolean = false; character set = utf8; AllowPublicKeyRetrieval = True; ";
        }
    }
}
