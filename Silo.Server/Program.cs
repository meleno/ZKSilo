﻿using Microsoft.Extensions.Configuration;
using NLog.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Silo.Config;
using Silo.Grains;
using System;
using System.Threading.Tasks;

namespace Silo.Server
{
	class Program
	{
		public static int Main(string[] args)
		{
			return RunMainAsync().Result;
		}

		private static async Task<int> RunMainAsync()
		{
			try
			{
				var host = await StartSilo2();
				Console.WriteLine("Press Enter to terminate...");
				Console.ReadLine();

				await host.StopAsync();

				return 0;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return 1;
			}
		}

		private static async Task<ISiloHost> StartSilo2()
		{
			IConfiguration config = SiloConfigurationProvider.GetSiloConfiguration();

			// define the cluster configuration
			var builder = new SiloHostBuilder()
				//.UseLocalhostClustering()
				//.Configure<ClusterOptions>(config)
				//.Configure<EndpointOptions>(config)
				//.Configure<AdoNetClusteringSiloOptions>(config)
				.Configure<ClusterOptions>(options =>
				{
					options.ClusterId = "Silo1";
					options.ServiceId = "ZKSilo";
				})
				.ConfigureEndpoints(siloPort: 11111, gatewayPort: 30000)
				.UseAdoNetClustering(options =>
				{
					options.ConnectionString = "Data Source=localhost\\SQLEXPRESS;database=Orleans;user=sa;password=Laurana";
					options.Invariant = "System.Data.SqlClient";
				})
				.ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(SavePunch).Assembly).WithReferences())
				.ConfigureLogging(logging =>
				{
					logging.AddNLog();
					//logging.AddConsole();
				})
				.UseDashboard(options =>
				{
					options.Username = "meleno";
					options.Password = "meleno";
					options.Port = 9191;
				});

			var host = builder.Build();
			await host.StartAsync();
			return host;
		}

		private static async Task<ISiloHost> StartSilo3()
		{
			ISiloConfiguration config = SiloConfigurationProvider.GetConfig();

			// define the cluster configuration
			var builder = new SiloHostBuilder();
			//	.UseLocalhostClustering()
			//	.Configure<ClusterOptions>( options => { options = config.ClusterConfig; })
			//	.Configure<EndpointOptions>(options => { options = config.EndPointConfig; })
			//	.Configure<AdoNetClusteringSiloOptions>(options => { options = config.ClusterDatabaseConfig; })
			//	//.ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(HelloGrain).Assembly).WithReferences())
			//	.ConfigureLogging(logging =>
			//	{
			//		logging.AddNLog();
			//		logging.AddConsole();
			//	});

			var host = builder.Build();
			await host.StartAsync();
			return host;
		}
	}
}
