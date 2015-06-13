using System;
using System.Diagnostics;
using BSU.FAMCS.LoadMonitoring.BusinessLayer.Model;
using BSU.FAMCS.LoadMonitoring.BusinessLayer.Monitor.Interface;
using BSU.FAMCS.LoadMonitoring.BusinessLayer.Utils;

namespace BSU.FAMCS.LoadMonitoring.BusinessLayer.Monitor
{
    public class RamMonitor: AbstractStepThread, IRamMonitor
    {
        private const int TimeToSleep = 2000;
        private readonly IBusinessResources _businessResources;
        private readonly ILogger _logger;
        private readonly PerformanceCounter _ramAvailableCounter;
        private readonly PerformanceCounter _ramPercentageCounter;

        public RamMonitor(IBusinessResources businessResources, ILogger logger):base(TimeToSleep)
        {
            _businessResources = businessResources;
            _logger = logger;
            _ramAvailableCounter =  new PerformanceCounter("Memory", "Available MBytes");
            _ramPercentageCounter = new PerformanceCounter("Memory", "% Committed Bytes in Use");
        }

        public void Start()
        {
            StartThread();
        }

        protected override void DoStep()
        {
            var ramModel = new Ram
            {
                AddDateTime = DateTime.Now, 
                FreeAmount = (int) _ramAvailableCounter.NextValue(),
                UsedPercentage = _ramPercentageCounter.NextValue()
            };
            _businessResources.AddRamEntry(ramModel);
            _logger.Save(ramModel.ToString());
        }

        public void Stop()
        {
            StopThread();
        }
    }
}
