using ConfigurationLibrary;
using ShopApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Services
{
    //Bound to DataAccessClient to run queries for specific tables
    public class DataAdapterClient
    {
        public DataAdapterClient(DataAccessClient dataAccessClient)
        {
            DataAccessClient = dataAccessClient;
        }

        public DataAccessClient DataAccessClient { get; }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            string sql = "SELECT * FROM Products";
            IEnumerable<Product> result = await DataAccessClient.Query<Product>(sql);
            return result;
        }
    }
}
