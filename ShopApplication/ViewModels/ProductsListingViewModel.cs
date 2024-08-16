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
        public MessegeStore MessegeStore { get; }

        private bool _isLoading;
		public bool IsLoading
		{
			get
			{
				return _isLoading;
			}
			set
			{
				_isLoading = value;
				OnPropertyChanged(nameof(IsLoading));
			}
		}

		public ProductsListingViewModel(DataAdapterClient dataAdapterClient,
			NavigationStore navigationStore,
			ShopStore shopStore,
			MessegeStore messegeStore)
        {
            DataAdapterClient = dataAdapterClient;
            NavigationStore = navigationStore;
            ShopStore = shopStore;
            MessegeStore = messegeStore;
            //_ = InitializeCollection();
            ProductsCollection = new(ShopStore.Products);
            ShopStore.CollectionChanged += ShopStore_CollectionChanged;
			MakeProductViewModelNavigationService = new(navigationStore,
				(obj) => {
					Product? p = obj as Product;
					if (p is null)
						return new MakeProductViewModel(DataAdapterClient,NavigationStore,ProductsCount,ShopStore,MessegeStore);
					
					return new MakeProductViewModel(DataAdapterClient, NavigationStore,p,ShopStore,MessegeStore);
				});
			ViewProductCommand = new NavigationCommand<MakeProductViewModel>(
				MakeProductViewModelNavigationService
				);
			LoadProductsCommand = new LoadProductsListingCommand(this, ShopStore);
        }
        public static ProductsListingViewModel LoadProductsListringViewModel(
			DataAdapterClient dataAdapterClient,
			NavigationStore navigationStore,
			ShopStore shopStore,
			MessegeStore messegeStore)
		{
			ProductsListingViewModel viewModel = new ProductsListingViewModel(
				dataAdapterClient,
				navigationStore,
				shopStore,
				messegeStore);
			viewModel.LoadProductsCommand.Execute(null);
			return viewModel;
		}

        private void ShopStore_CollectionChanged()
        {
			UpdateProducts();
        }

        private void UpdateProducts()
        {
			ProductsCollection.Clear();
			foreach (Product product in ShopStore.Products)
			{
				ProductsCollection.Add(product);
			}
			OnPropertyChanged(nameof(ProductsCollection));
        }
        #region Commands
        public ICommand ViewProductCommand { get; set; }
		public ICommand LoadProductsCommand { get; set; }
        #endregion
        /*private async Task InitializeCollection()
        {
			var products = await DataAdapterClient.GetProducts();
			ProductsCollection = new(products);
        }*/
    }
}
