using System;

namespace BSU.FAMCS.LoadMonitoring.BusinessLayer.Model
{
    public class Ram
    {
        public int Id { get; set; }
        public int FreeAmount{ get; set; }
        public double UsedPercentage { get; set; }
        public DateTime AddDateTime { get; set; }
    }
}
