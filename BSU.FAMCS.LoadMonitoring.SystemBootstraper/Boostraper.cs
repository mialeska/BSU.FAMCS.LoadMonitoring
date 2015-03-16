using BSU.FAMCS.LoadMonitoring.BusinessLayer;
using BSU.FAMCS.LoadMonitoring.DataBaseLayer;
using Microsoft.Practices.Unity;

namespace BSU.FAMCS.LoadMonitoring.SystemBootstraper
{
    public static class Boostraper
    {
        private static UnityContainer _container;

        static Boostraper()
        {
            _container = new UnityContainer();
            _container.RegisterType<IBusinessResources, DataBase>();
            _container.RegisterType<IBusiness, Business>();
        }

        public static IBusiness GetBusiness()
        {
            return _container.Resolve<IBusiness>();
        }
    }
}
