using CommonData;
using Dapper.Contrib.Extensions;
using Interfaces;
using Orleans;
using SiloConfig;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Silo.Implementations
{
	class SavePunch : Grain, ISavePunch
	{
		public Task<int> SavePunchInDatabase(Punch punchToSave)
		{
			using (var connection = new SqlConnection(SiloConfigurationProvider.GetConfig().DatabaseConfig.ConnectionString))
			{
				connection.Open();
				return connection.InsertAsync<Punch>(punchToSave);
			}
		}
	}
}
