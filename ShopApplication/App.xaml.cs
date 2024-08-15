using ConfigurationLibrary;
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
            navigationStore.CurrentViewModel = new ProductsListingViewModel(dataAdapterClient,navigationStore, shopStore);
            MainWindow window = new MainWindow()
            {
                DataContext = new MainViewModel(dataAdapterClient,navigationStore)
            };
            window.Show();
        }
    }

}
