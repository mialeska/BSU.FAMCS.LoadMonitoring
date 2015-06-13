using System;
using System.Collections.Generic;

namespace BSU.FAMCS.LoadMonitoring.BusinessLayer.Model
{
    public class HddDisk
    {
        public int Id { get; set; }
        public string DriveName { get; set; }
        public string VolumeLabel { get; set; }
        public DateTime AddDateTime { get; set; }

        public virtual List<DiskFreeSpace> HDiskFreeSpaceModels { get; set; }
        public int MbTotalAmount { get; set; }

        public override string ToString()
        {
            var result = string.Format("{0} {1} {2}", "\nHardDiskMonitor find new disk",
                    DriveName, AddDateTime.ToString("HH:mm:ss tt"));
            return result;
        }
    }
}
