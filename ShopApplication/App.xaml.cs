using ConfigurationLibrary;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
        IHost _host;
        
        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(services => 
                {
                    services.AddSingleton<DataAccessClient>();
                    services.AddSingleton<DataAdapterClient>();
                    services.AddSingleton<ShopStore>();
                    services.AddSingleton<NavigationStore>((ser) =>
                    {
                        NavigationStore store = new();
                        store.CurrentViewModel = MakeProductsListingViewModel(
                                ser.GetRequiredService<DataAdapterClient>(),
                                ser.GetRequiredService<ShopStore>(),
                                store,
                                ser.GetRequiredService<MessegeStore>()
                                );
                        return store;
                    });
                    services.AddSingleton<MessegeViewModel>();
                    services.AddSingleton<MessegeStore>();
                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<MainWindow>(s => 
                    {
                        return new MainWindow()
                        {
                            DataContext = s.GetRequiredService<MainViewModel>()
                        };
                    });
                })
                .Build();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            MainWindow window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();
        }

        private static ProductsListingViewModel MakeProductsListingViewModel(DataAdapterClient dataAdapterClient, 
            ShopStore shopStore, 
            NavigationStore navigationStore,
            MessegeStore messegeStore)
        {
            return ProductsListingViewModel.LoadProductsListringViewModel(dataAdapterClient, navigationStore, shopStore, messegeStore);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();
            base.OnExit(e);
        }
    }

}
