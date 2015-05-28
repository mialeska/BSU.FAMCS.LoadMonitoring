using System.Linq;
using BSU.FAMCS.LoadMonitoring.BusinessLayer.Model;

namespace BSU.FAMCS.LoadMonitoring.BusinessLayer.History
{


    public interface IHistoryProvider
    {
        IQueryable<Ram> GetLatestRamHistory();
        IQueryable<DiskFreeSpace> GetLatestHddHistory();
    }
}