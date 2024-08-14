using ShopApplication.Models;
using ShopApplication.Services;
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
        public ProductEditCommand(NavigationService<ViewModelBase> navigationService, DataAdapterClient dataAdapterClient)
        {
            NavigationService = navigationService;
            DataAdapterClient = dataAdapterClient;
        }
        public Product? SelectedProduct { get; set; }

        public NavigationService<ViewModelBase> NavigationService { get; }
        public DataAdapterClient DataAdapterClient { get; }

        public override void Execute(object? parameter) 
        {
            MessageBox.Show("Operation Successed");
            NavigationService.Navigate(null);
        }
       
    }
}
