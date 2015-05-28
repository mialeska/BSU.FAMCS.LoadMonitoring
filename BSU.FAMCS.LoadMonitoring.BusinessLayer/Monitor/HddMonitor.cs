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
        //private readonly PerformanceCounter _hddCounter;

        public HddMonitor(IBusinessResources iBusiness): base(TimeToSleep)
        {
            _businessResources = iBusiness;
            //_hddCounter = new PerformanceCounter("Логический диск", "% свободного места", "C:");
            //_hddCounter.NextValue();
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
                    var str = string.Format("{0} {1} {2}", "\nHardDiskMonitor find new disk",
                    curHddModel.DriveName, curHddModel.AddDateTime.ToString("HH:mm:ss tt"));
                    _businessResources.Save(str);
                }
                //_hddCounter.InstanceName = curHddModel.DriveName;

                var diskFreespaceModel = new DiskFreeSpace
                {
                    HddDiskId = curHddModel.Id,
                    HddDiskModel = curHddModel,
                    AddDateTime = DateTime.Now,
                    MbAvailable = (int)(drive.AvailableFreeSpace/1024/1024)
                };
                diskFreespaceModel.Percentage =(double) diskFreespaceModel.MbAvailable / curHddModel.MbTotalAmount;
                //diskFreespaceModel.Percentage = _hddCounter.NextValue();
                _businessResources.AddDiskFreeSpaceEntry(diskFreespaceModel);

                var strSave = string.Format("{0} {6}({1}) {2}MB free, {3}% free, {4}MB Total, {5}", "HardDiskMonitor working:",
                    curHddModel.DriveName, diskFreespaceModel.MbAvailable, diskFreespaceModel.Percentage, curHddModel.MbTotalAmount, diskFreespaceModel.AddDateTime.ToString("HH:mm:ss tt"), 
                    curHddModel.VolumeLabel);
                _businessResources.Save(strSave);
            }
        }

        public void Stop()
        {
           StopThread();
        }
    }
}
