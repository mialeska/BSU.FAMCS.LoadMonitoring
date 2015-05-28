using System.Web.Mvc;
using BSU.FAMCS.LoadMonitoring.StatisticCollectorApplication.Helper;
using BSU.FAMCS.LoadMonitoring.SystemBootstraper;


namespace BSU.FAMCS.LoadMonitoring.StatisticCollectorApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.MainMenu = MainMenuItems.Home;
            return View();
        }


        public ActionResult HddHistory()
        {
            ViewBag.MainMenu = MainMenuItems.HddHistory;

            var history = Bootstraper.GetHistoryProvider().GetLatestHddHistory();

            return View(history);
        }

        public ActionResult RamHistory()
        {
            ViewBag.MainMenu = MainMenuItems.RamHistory;

            var history = Bootstraper.GetHistoryProvider().GetLatestRamHistory();

            return View(history);
        }
    }
}
