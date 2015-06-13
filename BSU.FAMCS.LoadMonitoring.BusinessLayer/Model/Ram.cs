using System;

namespace BSU.FAMCS.LoadMonitoring.BusinessLayer.Model
{
    public class Ram
    {
        public int Id { get; set; }
        public int FreeAmount{ get; set; }
        public double UsedPercentage { get; set; }
        public DateTime AddDateTime { get; set; }
        public override string ToString()
        {
            var result = string.Format("{0}, Free {1}MB, Used {2}%", "Ram Monitor working:",
                FreeAmount, UsedPercentage);
            return result;
        }
    }
}
