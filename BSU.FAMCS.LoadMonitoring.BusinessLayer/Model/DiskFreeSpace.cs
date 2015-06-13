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

        public override string ToString()
        {
            var result = string.Format("{0} {6}({1}) {2}MB free, {3}% free, {4}MB Total, {5}", "HardDiskMonitor working:",
                    HddDiskModel.DriveName, MbAvailable, Percentage, HddDiskModel.MbTotalAmount, AddDateTime.ToString("HH:mm:ss tt"),
                    HddDiskModel.VolumeLabel);
            return result;
        }
    }
}
