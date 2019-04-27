using NLog.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.Runtime;
using Silo.Interfaces;
using System;
using System.Threading.Tasks;

namespace Silo.Client
{
	public static class SiloClient
	{
		const int initializeAttemptsBeforeFailing = 5;
		private static int attempt = 0;
		private static IClusterClient m_client;

		public static async Task<IClusterClient> GetSiloClient()
		{
			if (m_client == null)
			{
				m_client = new ClientBuilder()
					.Configure<ClusterOptions>(options =>
					{
						options.ClusterId = "Silo1";
						options.ServiceId = "ZKSilo";
					})
					.UseAdoNetClustering(options =>
					{
						options.ConnectionString = "Data Source=localhost\\SQLEXPRESS;database=Orleans;user=sa;password=Laurana";
						options.Invariant = "System.Data.SqlClient";
					})
					.ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(ISavePunch).Assembly).WithReferences())
					.ConfigureLogging(logging => logging.AddNLog())
					.Build();

				await m_client.Connect(RetryFilter);
			}

			return m_client;
		}

		private static async Task<bool> RetryFilter(Exception exception)
		{
			if (exception.GetType() != typeof(SiloUnavailableException))
			{
				Console.WriteLine($"Cluster client failed to connect to cluster with unexpected error.  Exception: {exception}");
				return false;
			}
			attempt++;
			Console.WriteLine($"Cluster client attempt {attempt} of {initializeAttemptsBeforeFailing} failed to connect to cluster.  Exception: {exception}");
			if (attempt > initializeAttemptsBeforeFailing)
			{
				return false;
			}
			await Task.Delay(TimeSpan.FromSeconds(4));
			return true;
		}
	}
}
