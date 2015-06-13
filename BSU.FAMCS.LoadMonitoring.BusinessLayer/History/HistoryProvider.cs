using System.Linq;
using BSU.FAMCS.LoadMonitoring.BusinessLayer.Model;

namespace BSU.FAMCS.LoadMonitoring.BusinessLayer.History
{
    public class HistoryProvider: IHistoryProvider
    {
        private readonly IHistoryResources _resources;

        public HistoryProvider(IHistoryResources resources)
        {
            _resources = resources;
        }
        
        public IQueryable<Ram> GetLatestRamHistory()
        {
            return _resources.GetLatestRamHistory();
        }

        public IQueryable<DiskFreeSpace> GetLatestHddHistory()
        {
            return _resources.GetLatestHddHistory();
        }
    }
}