using Silo.Common;
using System.Threading.Tasks;

namespace Silo.Interfaces
{
	public interface ISavePunch : Orleans.IGrainWithIntegerKey
	{
		Task<int> SavePunchInDatabase(Punch punch);
	}
}
