using ShopApplication.Services;
using ShopApplication.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public NavigationStore NavigationStore { get; set; }
        public ViewModelBase CurrentViewModel => NavigationStore.CurrentViewModel;
        public DataAdapterClient DataAdapterClient { get; }

        public MainViewModel(DataAdapterClient dataAdapterClient, NavigationStore store)
        {
            DataAdapterClient = dataAdapterClient;
            
            NavigationStore = store;
            NavigationStore.CurrentViewModelChagned += CurrentViewModelChanged;
        }

        private void CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
