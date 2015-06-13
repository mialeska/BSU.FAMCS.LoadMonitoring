using BSU.FAMCS.LoadMonitoring.BusinessLayer.Model;

namespace BSU.FAMCS.LoadMonitoring.BusinessLayer
{
    public interface IBusinessResources
    {
        HddDisk GetHDiskModel(string driveName);
        void AddDisk(HddDisk hdModel);
        void AddDiskFreeSpaceEntry(DiskFreeSpace diskSpaceModel);
        void AddRamEntry(Ram ramModel);

    }
}
