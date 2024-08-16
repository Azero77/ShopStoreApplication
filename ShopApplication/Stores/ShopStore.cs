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
        public Lazy<Task> _initialize;
        public DataAdapterClient DataAdapterClient { get; }
        public event Action CollectionChanged;

        public ShopStore(DataAdapterClient dataAdapterClient)
        {
            _products = new List<Product>();
            DataAdapterClient = dataAdapterClient;
            _initialize = new Lazy<Task>(Initialize);
            Load();
        }

        public async Task Load()
        {
            await _initialize.Value;
        }

        private async Task Initialize()
        {
            IEnumerable<Product> products = await DataAdapterClient.GetProducts();
            Products.Clear();
            Products.AddRange(products);
            OnCollectionChanged();
        }

        public void CreateElement(Product p) 
        {
            Products.Add(p);
            OnCollectionChanged();
            
        }
        public void AlterElement(Product p)
        {
            Products.First(product => product.Id == p.Id).EditProduct(p);
            OnCollectionChanged();
        }

        public void OnCollectionChanged()
        { 
            CollectionChanged?.Invoke();
        }
    }
}
