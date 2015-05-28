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
    }
}
