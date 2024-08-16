using ShopApplication.Models;
using ShopApplication.Services;
using ShopApplication.Stores;
using ShopApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopApplication.Commands
{
    public abstract class ProductEditCommand : CommandBase
    {
        public ProductEditCommand(NavigationService<ViewModelBase> navigationService, DataAdapterClient dataAdapterClient,ShopStore shopStore,MessegeStore messegeStore)
        {
            NavigationService = navigationService;
            DataAdapterClient = dataAdapterClient;
            ShopStore = shopStore;
            MessegeStore = messegeStore;
        }
        public Product? SelectedProduct { get; set; }

        public NavigationService<ViewModelBase> NavigationService { get; }
        public DataAdapterClient DataAdapterClient { get; }
        public ShopStore ShopStore { get; }
        public MessegeStore MessegeStore { get; }

        public override void Execute(object? parameter) 
        {
            MessegeStore.SetMessege("Operation Succeded", Messege.Status);
            NavigationService.Navigate(null);
        }
        public override bool CanExecute(object? parameter)
        {
            MakeProductViewModel? ProductViewModel = parameter as MakeProductViewModel;
            if (ProductViewModel is null || (ProductViewModel?.HasErrors ?? false))
                return false;
            SelectedProduct = new(
                ProductViewModel.Id,
                ProductViewModel.Category?.Id,
                ProductViewModel.ModelNumber,
                ProductViewModel.ModelName,
                ProductViewModel.Cost,
                ProductViewModel.Description
                );
            if (SelectedProduct is null)
                return false;
            foreach (var property in SelectedProduct.GetType().GetProperties())
            {
                if (property.GetValue(SelectedProduct) is null)
                    return false;
            }
            return true;
        }
    }
}
