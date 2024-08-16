using ConfigurationLibrary;
using ShopApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            await Task.Delay(3000);
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

        #region Edit
        

        public async Task<int> EditProduct(string sql,Product product,Func<string,object,Task<int>> func) 
        {
            int Result;
            object param = new
            {
                categoryId = product.CategoryId,
                modelNumber = product.ModelNumber,
                modelName = product.ModelName,
                cost = product.Cost,
                description = product.Description,
                id = product.Id,
            };
            try
            {
                Result = await func(sql, param);
            }
            catch (Exception)
            {

                throw;
            }
            if (Result != 1)
                throw new InvalidDataException();
            return Result;
        }
        public async Task<int> NewProduct(Product product)
        {
            string sql = "INSERT INTO Products " +
                "(CategoryId, ModelNumber, ModelName, Cost, Description) " +
                "VALUES (@categoryId, @modelNumber, @cost, @modelName, @description)";
            int Result = await EditProduct(sql, product, DataAccessClient.Execute);
            return Result;

        }
        public async Task<int> UpdateProduct(Product product)
        {
            string sql = "UPDATE Products " +
                "SET CategoryId = @categoryId, ModelNumber = @modelNumber, ModelName = @modelName, Cost = @cost, Description = @description " +
                "WHERE Id = @id";
            int Result = await EditProduct(sql, product, DataAccessClient.Execute);
            return Result;
        }
        #endregion
    }
}
