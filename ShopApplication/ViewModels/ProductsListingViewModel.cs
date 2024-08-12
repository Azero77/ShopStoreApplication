using ShopApplication.Models;
using ShopApplication.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.ViewModels
{
    public class ProductsListingViewModel : ViewModelBase
    {
		private ObservableCollection<Product> _productsCollection;
		public ObservableCollection<Product> ProductsCollection
		{
			get
			{
				return _productsCollection;
			}
			set
			{
				_productsCollection = value;
				OnPropertyChanged(nameof(ProductsCollection));
			}
		}

        public DataAdapterClient DataAdapterClient { get; }

        public ProductsListingViewModel(DataAdapterClient dataAdapterClient)
        {
            DataAdapterClient = dataAdapterClient;
			_ = InitializeCollection();

        }

        private async Task InitializeCollection()
        {
			var products = await DataAdapterClient.GetProducts();
			ProductsCollection = new(products);
        }
    }
}
