﻿using Database.Common;
using Database.IDatabase;

namespace Database.ConnectionStringProvider
{
	public class MySQLConnectionStringProvider : IConnectionStringProvider
	{
		public string GetDatabaseConnectionString(DatabaseConfig config)
		{
			return $"Data Source = {config.ServerAddress}; Port ={config.ServerPort}; Database ={config.DatabaseName}; User ID = {config.UserName}; Password ={config.Password}; pooling = true; SslMode ={config.UseSSL}; connection lifetime = 300; Treat Tiny As Boolean = false; character set = utf8; AllowPublicKeyRetrieval = True; ";
		}

		public string GetServerConnectionString(DatabaseConfig config)
		{
			return $"Data Source = {config.ServerAddress}; Port ={config.ServerPort}; User ID = {config.UserName}; Password ={config.Password}; pooling = true; SslMode ={config.UseSSL}; connection lifetime = 300; Treat Tiny As Boolean = false; character set = utf8; AllowPublicKeyRetrieval = True;";
		}
	}
}
