using CommonData;
using System.Threading.Tasks;

namespace Interfaces
{
	public interface ISavePunch
	{
		Task<int> SavePunchInDatabase(Punch punch);
	}
}
