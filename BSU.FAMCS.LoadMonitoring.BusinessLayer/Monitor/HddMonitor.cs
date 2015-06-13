using System;
using System.IO;
using BSU.FAMCS.LoadMonitoring.BusinessLayer.Model;
using BSU.FAMCS.LoadMonitoring.BusinessLayer.Monitor.Interface;
using BSU.FAMCS.LoadMonitoring.BusinessLayer.Utils;

namespace BSU.FAMCS.LoadMonitoring.BusinessLayer.Monitor
{
    public class HddMonitor : AbstractStepThread, IHddMonitor
    {
        private const int TimeToSleep = 2000;
        private readonly IBusinessResources _businessResources;
        private readonly ILogger _logger;

        public HddMonitor(IBusinessResources iBusiness, ILogger logger): base(TimeToSleep)
        {
            _businessResources = iBusiness;
            _logger = logger;
        }

        public void Start()
        {
            StartThread();
        }

        protected override void DoStep()
        {
            var drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                if(!drive.IsReady || drive.DriveType!=DriveType.Fixed)
                    continue;

                var curHddModel = _businessResources.GetHDiskModel(drive.Name.TrimEnd('\\'));
                if (curHddModel == null)
                {
                    curHddModel = new HddDisk
                    {
                        DriveName = drive.Name.TrimEnd('\\'),
                        VolumeLabel = drive.VolumeLabel,
                        AddDateTime = DateTime.Now,
                        MbTotalAmount = (int) (drive.TotalSize /1024/1024)
                    };
                    //this should set the ID
                    _businessResources.AddDisk(curHddModel);
                    _logger.Save(curHddModel.ToString());
                }

                var diskFreespaceModel = new DiskFreeSpace
                {
                    HddDiskId = curHddModel.Id,
                    HddDiskModel = curHddModel,
                    AddDateTime = DateTime.Now,
                    MbAvailable = (int)(drive.AvailableFreeSpace/1024/1024)
                };
                diskFreespaceModel.Percentage =(double) diskFreespaceModel.MbAvailable / curHddModel.MbTotalAmount;
                _businessResources.AddDiskFreeSpaceEntry(diskFreespaceModel);
                _logger.Save(diskFreespaceModel.ToString());
            }
        }

        public void Stop()
        {
           StopThread();
        }
    }
}
