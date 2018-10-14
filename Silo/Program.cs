using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Orleans.Configuration;
using Orleans.Hosting;
using SiloConfig;
using System;
using System.Threading.Tasks;

namespace Silo
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
				.UseLocalhostClustering()
				.Configure<ClusterOptions>(config)
				.Configure<EndpointOptions>(config)
				.Configure<AdoNetClusteringSiloOptions>(config)
				//.ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(HelloGrain).Assembly).WithReferences())
				.ConfigureLogging(logging =>
				{
					logging.AddNLog();
					logging.AddConsole();
				});

			var host = builder.Build();
			await host.StartAsync();
			return host;
		}
	}
}
