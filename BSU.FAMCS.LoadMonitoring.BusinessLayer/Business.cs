namespace BSU.FAMCS.LoadMonitoring.BusinessLayer
{
    public interface IBusinessResources
    {
        void Save(string toSave);
    }

    public interface IBusiness
    {
        void Do();
    }

    public class Business: IBusiness
    {
        private readonly IBusinessResources _iBusiness;

        public Business(IBusinessResources iBusiness)
        {
            _iBusiness = iBusiness;
        }

        public void Do()
        {
            _iBusiness.Save("good news!");
        }
    }
}
