using System.Collections.Generic;
using System.Linq;
using BSU.FAMCS.LoadMonitoring.BusinessLayer.Model;

namespace BSU.FAMCS.LoadMonitoring.BusinessLayer.History
{


    public class HistoryProvider: IHistoryProvider
    {
        private readonly IHistoryResources _resources;

        public HistoryProvider(IHistoryResources resources)
        {
            _resources = resources;
        }

        /*
        private readonly SqlConnection _connection;

        public HistoryProvider()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);
            _connection.Open();
        }

        public IEnumerable<Ram> GetLatestRamHistory()
        {
            var command = new SqlCommand("select top 20 * from Rams order by id desc", _connection);
            //SELECT * FROM [MyTable] WHERE [id] > (SELECT MAX([id]) - 5 FROM [MyTable])
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var ramEntry = new Ram
                {
                    Id = (int) reader["Id"],
                    FreeAmount = (int) reader["FreeAmount"],
                    AddDateTime = (DateTime) reader["AddDateTime"],
                    UsedPercentage = (double) reader["UsedPercentage"]
                };

                yield return ramEntry;
            }
            reader.Close();
        }
        */

        public IQueryable<Ram> GetLatestRamHistory()
        {
            return _resources.GetLatestRamHistory();
        }

        public IQueryable<DiskFreeSpace> GetLatestHddHistory()
        {
            return _resources.GetLatestHddHistory();
        }
    }
}