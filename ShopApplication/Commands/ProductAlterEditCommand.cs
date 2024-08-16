using ShopApplication.Services;
using ShopApplication.Stores;
using ShopApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Commands
{
    public class ProductUpdateEditCommand : ProductEditCommand
    {
        public ProductUpdateEditCommand(NavigationService<ViewModelBase> navigationService, DataAdapterClient dataAdapterClient,ShopStore shopStore,MessegeStore messegeStore) : base(navigationService, dataAdapterClient,shopStore,messegeStore)
        {
        }

        public override async void Execute(object? parameter)
        {
            MakeProductViewModel ProductViewModel = parameter as MakeProductViewModel;
            if (ProductViewModel is null)
                throw new InvalidCastException();
            SelectedProduct = new(
                ProductViewModel.Id,
                ProductViewModel.Category?.Id,
                ProductViewModel.ModelNumber,
                ProductViewModel.ModelName,
                ProductViewModel.Cost,
                ProductViewModel.Description
                );
            await DataAdapterClient.UpdateProduct(SelectedProduct);
            ShopStore.AlterElement(SelectedProduct);
            base.Execute(parameter);
        }
    }
}
