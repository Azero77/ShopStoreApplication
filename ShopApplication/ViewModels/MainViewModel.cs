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
        public MessegeStore MessegeStore { get; }

        public ViewModelBase CurrentViewModel => NavigationStore.CurrentViewModel;
        public MessegeViewModel CurrentMessegeViewModel => MessegeStore.MessegeViewModelIndicator;
        public DataAdapterClient DataAdapterClient { get; }

        public MainViewModel(DataAdapterClient dataAdapterClient, NavigationStore store, MessegeStore messegeStore)
        {
            DataAdapterClient = dataAdapterClient;
            
            NavigationStore = store;
            MessegeStore = messegeStore;
            NavigationStore.CurrentViewModelChagned += CurrentViewModelChanged;
            MessegeStore.MessegeChanged += MessegeStore_MessegeChanged;
        }

        private void MessegeStore_MessegeChanged(string message, Messege messegeType)
        {
            OnPropertyChanged(nameof(CurrentMessegeViewModel));
        }

        private void CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        
    }
}
