using Dapper.Contrib.Extensions;
using Orleans;
using Silo.Common;
using Silo.Config;
using Silo.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Silo.Grains
{
	public class SavePunch : Grain, ISavePunch
	{
		public async Task<int> SavePunchInDatabase(Punch punchToSave)
		{
			using (IDbConnection connection = new SqlConnection(SiloConfigurationProvider.GetConfig().ConnectionString))
			{
				connection.Open();
				return await connection.InsertAsync(punchToSave);
			}
		}
	}
}
