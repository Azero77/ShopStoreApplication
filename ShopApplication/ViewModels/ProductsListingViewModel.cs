using ShopApplication.Commands;
using ShopApplication.Models;
using ShopApplication.Services;
using ShopApplication.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopApplication.ViewModels
{
    public class ProductsListingViewModel : ViewModelBase
    {
		private ObservableCollection<Product>? _productsCollection;
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
		public int ProductsCount => ProductsCollection.Count();
		public NavigationService<ViewModelBase> MakeProductViewModelNavigationService { get; set; }

        public DataAdapterClient DataAdapterClient { get; }
        public NavigationStore NavigationStore { get; }
        public ShopStore ShopStore { get; }

        public ProductsListingViewModel(DataAdapterClient dataAdapterClient, NavigationStore navigationStore,ShopStore shopStore)
        {
            DataAdapterClient = dataAdapterClient;
            NavigationStore = navigationStore;
            ShopStore = shopStore;
            //_ = InitializeCollection();
			ProductsCollection = new(ShopStore.Products);
			MakeProductViewModelNavigationService = new(navigationStore,
				(obj) => {
					Product? p = obj as Product;
					if (p is null)
						return new MakeProductViewModel(DataAdapterClient,NavigationStore,ProductsCount,ShopStore);
					
					return new MakeProductViewModel(DataAdapterClient, NavigationStore,p,ShopStore);
				});
			ViewProductCommand = new NavigationCommand<MakeProductViewModel>(
				MakeProductViewModelNavigationService
				);
			
        }
        #region Commands
		public ICommand ViewProductCommand { get; set; }
        #endregion
        /*private async Task InitializeCollection()
        {
			var products = await DataAdapterClient.GetProducts();
			ProductsCollection = new(products);
        }*/
    }
}
