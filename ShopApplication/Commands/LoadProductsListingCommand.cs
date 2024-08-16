using ShopApplication.Stores;
using ShopApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Commands
{
    public class LoadProductsListingCommand : AsyncCommandBase
    {
        public LoadProductsListingCommand(ProductsListingViewModel viewModel, ShopStore shopStore)
        {
            ViewModel = viewModel;
            ShopStore = shopStore;
        }

        public ProductsListingViewModel ViewModel { get; }
        public ShopStore ShopStore { get; }

        public override async Task ExecuteAsync(object? parameter)
        {
            ViewModel.IsLoading = true;
            try
            {
                await ShopStore.Load();

            }
            catch (Exception)
            {
                throw;
            }
            ViewModel.IsLoading = false;
        }
    }
}
