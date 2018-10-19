using Config.Net;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SiloConfig
{
	public static class SiloConfigurationProvider
	{
		private static IConfiguration m_siloConfiguration;

		public static IConfiguration GetSiloConfiguration()
		{
			if (m_siloConfiguration == null)
			{
				var configBuilder = new ConfigurationBuilder()
						  .SetBasePath(Directory.GetCurrentDirectory())
						  .AddJsonFile("config2.json", reloadOnChange: true, optional: false);

				m_siloConfiguration = configBuilder.Build();
			}

			return m_siloConfiguration;
		}

		public static ISiloConfiguration GetConfig()
		{
			return new ConfigurationBuilder<ISiloConfiguration>()
				.UseJsonFile("config2.json")
				.Build();
		}
	}
}
