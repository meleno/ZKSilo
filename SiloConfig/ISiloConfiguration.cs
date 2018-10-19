using Orleans.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiloConfig
{
	public interface ISiloConfiguration
	{
		ClusterOptions ClusterConfig { get; set; }

		EndpointOptions EndPointConfig { get; set; }

		AdoNetClusteringSiloOptions ClusterDatabaseConfig { get; set; }

		AdoNetClusteringSiloOptions DatabaseConfig { get; set; }
	}
}
