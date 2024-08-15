using ShopApplication.Models;
using ShopApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Stores
{
    //Stores the Collection of Products Fetched From DataBase
    public class ShopStore
    {
        private List<Product> _products;
        public List<Product> Products => _products;

        public DataAdapterClient DataAdapterClient { get; }

        public ShopStore(DataAdapterClient dataAdapterClient)
        {
            _products = new List<Product>();
            DataAdapterClient = dataAdapterClient;
            Load(DataAdapterClient);
        }

        private async Task Load(DataAdapterClient dataAdapterClient)
        {
            IEnumerable<Product> products = await dataAdapterClient.GetProducts();
            Products.Clear();
            Products.AddRange(products);
        }

        public void CreateElement(Product p) 
        {
            Products.Add(p);
        }
        public void AlterElement(Product p)
        {
            Products.First(product => product.Id == p.Id).EditProduct(p);
        }
    }
}
