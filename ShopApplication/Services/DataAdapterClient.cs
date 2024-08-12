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

        public async Task<int> GetProductsCount()
        {
            string sql = "SELECT COUNT(*) FROM Products";
            int Count = await DataAccessClient.ExecuteScaler<int>(sql,null);
            return Count;
        }

        public async Task<IEnumerable<Product>> GetProductsByProperty(string propertyName,object parameters)
        {
            string sql = "SELECT @property FROM Products";
            object param = new { property = propertyName };
            IEnumerable<Product> result = await DataAccessClient.Query<Product>(sql, param);
            return result;
        }

        public async Task<IEnumerable<Category>> Categories()
        {
            string sql = "SELECT * FROM Categories";
            IEnumerable<Category> result = await DataAccessClient.Query<Category>(sql);
            return result;
        }
    }
}
