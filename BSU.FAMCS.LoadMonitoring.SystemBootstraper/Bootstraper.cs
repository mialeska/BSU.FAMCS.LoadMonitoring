using BSU.FAMCS.LoadMonitoring.BusinessLayer;
using BSU.FAMCS.LoadMonitoring.BusinessLayer.History;
using BSU.FAMCS.LoadMonitoring.BusinessLayer.Monitor;
using BSU.FAMCS.LoadMonitoring.BusinessLayer.Monitor.Interface;
using BSU.FAMCS.LoadMonitoring.BusinessLayer.Utils;
using BSU.FAMCS.LoadMonitoring.DataBaseLayer;
using Microsoft.Practices.Unity;

namespace BSU.FAMCS.LoadMonitoring.SystemBootstraper
{
    public static class Bootstraper
    {
        private static readonly UnityContainer Container;

        static Bootstraper()
        {
            Container = new UnityContainer();
            Container.RegisterType<IBusinessResources, DataBase>();
            Container.RegisterType<IHistoryResources, DataBase>();
            Container.RegisterType<IRamMonitor, RamMonitor>();
            Container.RegisterType<IHddMonitor, HddMonitor>();
            Container.RegisterType<IHistoryProvider, HistoryProvider>();
            Container.RegisterType<ILogger, Logger>();
        }

        public static IHddMonitor GetHddMonitor()
        {
            return Container.Resolve<IHddMonitor>();
        }

        public static IRamMonitor GetMemoryMonitor()
        {
            return Container.Resolve<IRamMonitor>();
        }

        public static IHistoryProvider GetHistoryProvider()
        {
            return Container.Resolve<IHistoryProvider>();
        }
    }
}
