namespace BSU.FAMCS.LoadMonitoring.BusinessLayer.Utils
{
    public class Logger: ILogger
    {
        public void Save(string toSave)
        {
            System.Console.WriteLine(toSave);
        }
    }
}
