using CommonData;
using Dapper.Contrib.Extensions;
using Interfaces;
using Orleans;
using Silo.Config;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Silo.Grains
{
	public class SavePunch : Grain, ISavePunch
	{
		public Task<int> SavePunchInDatabase(Punch punchToSave)
		{
			using (var connection = new SqlConnection(SiloConfigurationProvider.GetConfig().DatabaseConfig.ConnectionString))
			{
				connection.Open();
				return connection.InsertAsync(punchToSave);
			}
		}
	}
}
