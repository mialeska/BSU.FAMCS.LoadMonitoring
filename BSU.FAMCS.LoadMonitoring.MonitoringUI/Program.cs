using BSU.FAMCS.LoadMonitoring.SystemBootstraper;

namespace BSU.FAMCS.LoadMonitoring.MonitoringUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var myBusiness = Boostraper.GetBusiness();
            myBusiness.Do();
        }
    }
}
