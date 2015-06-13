using System.Data.Entity;
using System.Linq;
using BSU.FAMCS.LoadMonitoring.BusinessLayer;
using BSU.FAMCS.LoadMonitoring.BusinessLayer.Model;

namespace BSU.FAMCS.LoadMonitoring.DataBaseLayer
{
    public class DataBase: DbContext, IBusinessResources, IHistoryResources
    {
        public DbSet<HddDisk> DiskModels { get; set; }
        public DbSet<DiskFreeSpace> DiskSpaceModels { get; set; }
        public DbSet<Ram> RamModels { get; set; }

        public HddDisk GetHDiskModel(string driveName)
        {
            return DiskModels.SingleOrDefault(it => it.DriveName == driveName);
        }

        public void AddDisk(HddDisk discModel)
        {
            DiskModels.Add(discModel);
            SaveChanges();
        }

        public void AddDiskFreeSpaceEntry(DiskFreeSpace diskSpaceModel)
        {
            DiskSpaceModels.Add(diskSpaceModel);
            SaveChanges();
        }

        public void AddRamEntry(Ram ramModel)
        {
            RamModels.Add(ramModel);
            SaveChanges();
        }

        public IQueryable<Ram> GetLatestRamHistory()
        {
            var items = RamModels.OrderByDescending(it => it.Id).Take(20);
            return items;
        }

        public IQueryable<DiskFreeSpace> GetLatestHddHistory()
        {
            var items = DiskSpaceModels.OrderByDescending(it => it.Id).Take(20);
            return items;
        }
    }
}
