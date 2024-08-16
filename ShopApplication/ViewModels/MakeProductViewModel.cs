using ShopApplication.Commands;
using ShopApplication.Converters;
using ShopApplication.Models;
using ShopApplication.Services;
using ShopApplication.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace ShopApplication.ViewModels
{
	public class MakeProductViewModel : ErrorViewModelBase, INotifyDataErrorInfo
	{
		//Edit Constructor
		public MakeProductViewModel(DataAdapterClient dataAdapterClient, NavigationStore navigationStore, Product p,ShopStore shopStore,MessegeStore messegeStore)
		{
			Id = p.Id;
			ModelNumber = p.ModelNumber;
			CategoryId = p.CategoryId;
			ModelName = p.ModelName;
			Cost = p.Cost;
			Description = p.Description;
			DataAdapterClient = dataAdapterClient;
			NavigationStore = navigationStore;
            ShopStore = shopStore;
            MessegeStore = messegeStore;
            NavigationService = new(NavigationStore, (obj) =>
            {
                return new ProductsListingViewModel(DataAdapterClient, NavigationStore,ShopStore,MessegeStore);
            });
			NavigationToProductListingViewCommand = new NavigationCommand<ProductsListingViewModel>(NavigationService);
            EditProductCommand = new ProductUpdateEditCommand(NavigationService, DataAdapterClient,ShopStore,MessegeStore);
            LoadCategories();
		}

		//Insert Constructor
		public MakeProductViewModel(DataAdapterClient dataAdapterClient, NavigationStore navigationStore, int Count,ShopStore shopStore, MessegeStore messegeStore)
		{
			Id = Count + 1;
            ShopStore = shopStore;
            MessegeStore = messegeStore;
            DataAdapterClient = dataAdapterClient;
			NavigationStore = navigationStore;
			NavigationService = new(navigationStore, (obj) =>
			{
				return new ProductsListingViewModel(DataAdapterClient, NavigationStore,ShopStore, MessegeStore);
			});
			MessegeIndicatorViewModel = new();
			NavigationToProductListingViewCommand = new NavigationCommand<ProductsListingViewModel>(NavigationService);
			EditProductCommand = new ProductInsertEditCommand(this,NavigationService, DataAdapterClient,ShopStore, MessegeStore);
			LoadCategories();
		}

		private void LoadCategories()
		{
			DataAdapterClient.Categories().ContinueWith((task) =>
			{
				Categories = task.Result;
				Category = Categories.FirstOrDefault(c => c.Id == CategoryId);

				OnPropertyChanged(nameof(Categories));

			});
		}
		#region Properties
		private int id;
		public int Id
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
				OnPropertyChanged(nameof(Id));
			}
		}
		public int? CategoryId { get; set; }
		private Category? category;
		public Category? Category
		{
			get
			{
				return category;
			}
			set
			{
				category = value;
				OnPropertyChanged(nameof(Category));
			}
		}

		private int? modelNumber;
		public int? ModelNumber
		{
			get
			{
				return modelNumber;
			}
			set
			{
				modelNumber = value;
				OnPropertyChanged(nameof(ModelNumber));
			}
		}

		private string? modelName;
		public string? ModelName
		{
			get
			{
				return modelName;
			}
			set
			{
				modelName = value;
				OnPropertyChanged(nameof(ModelName));
			}
		}

		private decimal? cost;
		public decimal? Cost
		{
			get
			{
				return cost;
			}
			set
			{
				cost = value;
				OnPropertyChanged(nameof(Cost));
			}
		}

		private string? description;


		public string? Description
		{
			get
			{
				return description;
			}
			set
			{
				description = value;
				OnPropertyChanged(nameof(Description));
			}
		}
		public NavigationService<ViewModelBase> NavigationService;

		public DataAdapterClient DataAdapterClient { get; }
		public NavigationStore NavigationStore { get; }
        public ShopStore ShopStore { get; }
        public MessegeStore MessegeStore { get; }
        public IEnumerable<Category> Categories { get; set; } = Enumerable.Empty<Category>();

		#endregion

		#region Commands
		public ICommand NavigationToProductListingViewCommand { get; set; }
		public ProductEditCommand EditProductCommand { get; set; }
        #endregion

        public override void OnPropertyChanged(string propertyName)
        {
			EditProductCommand?.OnCanExecuteChanged();
            base.OnPropertyChanged(propertyName);
        }
    }
}
