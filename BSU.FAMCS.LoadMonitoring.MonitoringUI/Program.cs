using System;
using System.Diagnostics;
using BSU.FAMCS.LoadMonitoring.SystemBootstraper;

namespace BSU.FAMCS.LoadMonitoring.MonitoringUI
{
    
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            /*
            var perfCategs = PerformanceCounterCategory.GetCategories();
            foreach (var perf in perfCategs)
            {System.IO.DriveInfo.GetDrives()
                Console.WriteLine(perf.CategoryName);
            }
            */
            var memory = Bootstraper.GetMemoryMonitor();
            memory.Start();
            
            var hardDisk = Bootstraper.GetHddMonitor();
            hardDisk.Start();
            
        }
    }
}
