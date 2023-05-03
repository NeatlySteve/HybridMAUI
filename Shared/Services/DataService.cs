using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources.Services
{
    public class DataService : IDataService
    {
        public DataService()
        {

        }
        public Task<List<string>> GetData()
        {
            return Task.FromResult( new List<string>()
            {
                "Kincaid Lake State Park",
                "Natural Bridge State Resort Park",
                "Carter Caves State Resort Park",
                "Blue Licks Battlefield State Park"
            });
        }
    }
}
