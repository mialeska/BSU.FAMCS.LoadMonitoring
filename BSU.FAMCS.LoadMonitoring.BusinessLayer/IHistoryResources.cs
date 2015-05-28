using System.Collections.Generic;
using System.Linq;
using BSU.FAMCS.LoadMonitoring.BusinessLayer.Model;

namespace BSU.FAMCS.LoadMonitoring.BusinessLayer
{
    public interface IHistoryResources
    {
        IQueryable<Ram> GetLatestRamHistory();
        IQueryable<DiskFreeSpace> GetLatestHddHistory();
    }
}
