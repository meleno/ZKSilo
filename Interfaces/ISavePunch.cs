using CommonData;
using System.Threading.Tasks;
using Orleans;

namespace Interfaces
{
	public interface ISavePunch : IGrainWithIntegerKey
	{
		Task<int> SavePunchInDatabase(Punch punch);
	}
}
