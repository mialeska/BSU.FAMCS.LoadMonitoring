using System;

namespace BSU.FAMCS.LoadMonitoring.BusinessLayer.Model
{
    public class DiskFreeSpace
    {
        public int Id { get;  set; }
        public double Percentage { get; set; }
        public int MbAvailable { get; set; }
        public DateTime AddDateTime { get; set; }
        
        public int HddDiskId { get; set; }
        public virtual HddDisk HddDiskModel { get; set; }
    }
}
