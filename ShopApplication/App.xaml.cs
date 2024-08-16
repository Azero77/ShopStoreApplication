﻿using ConfigurationLibrary;
using ShopApplication.Services;
using ShopApplication.Stores;
using ShopApplication.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ShopApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
            DataAccessClient dataAccessClient = new();
            DataAdapterClient dataAdapterClient = new(dataAccessClient);
            ShopStore shopStore = new(dataAdapterClient);
            NavigationStore navigationStore = new();
            MessegeStore messegeStore = new(new MessegeViewModel());
            navigationStore.CurrentViewModel = MakeProductsListingViewModel(dataAdapterClient, shopStore, navigationStore, messegeStore);
            MainWindow window = new MainWindow()
            {
                DataContext = new MainViewModel(dataAdapterClient, navigationStore, messegeStore)
            };
            window.Show();
        }

        private static ProductsListingViewModel MakeProductsListingViewModel(DataAdapterClient dataAdapterClient, 
            ShopStore shopStore, 
            NavigationStore navigationStore,
            MessegeStore messegeStore)
        {
            return ProductsListingViewModel.LoadProductsListringViewModel(dataAdapterClient, navigationStore, shopStore, messegeStore);
        }
    }

}
