using System;
using BSU.FAMCS.LoadMonitoring.BusinessLayer;

namespace BSU.FAMCS.LoadMonitoring.DataBaseLayer
{
    public class DataBase: IBusinessResources
    {
        public void Save(string toSave)
        {
            Console.WriteLine(toSave);
        }
    }
}
