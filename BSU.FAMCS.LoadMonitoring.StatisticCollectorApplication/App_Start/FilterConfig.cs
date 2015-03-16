using System.Web;
using System.Web.Mvc;

namespace BSU.FAMCS.LoadMonitoring.StatisticCollectorApplication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}