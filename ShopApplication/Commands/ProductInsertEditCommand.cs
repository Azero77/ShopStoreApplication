using ShopApplication.Models;
using ShopApplication.Services;
using ShopApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Commands
{
    public class ProductInsertEditCommand : ProductEditCommand
    {
        public ProductInsertEditCommand(NavigationService<ViewModelBase> navigationService, DataAdapterClient dataAdapterClient) : base(navigationService, dataAdapterClient)
        {
        }

        public async override void Execute(object? parameter)
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
            int Result = await DataAdapterClient.NewProduct(SelectedProduct);
            if (Result != 1)
                throw new InvalidDataException();
            base.Execute(parameter);
        }
    }
}
