using ShopApplication.Stores;
using ShopApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Services
{
    public class NavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        public NavigationService(NavigationStore navigationStore, Func<object,TViewModel> ViewModel)
        {
            NavigationStore = navigationStore;
            this.ViewModel = ViewModel;
        }

        public NavigationStore NavigationStore { get; }
        public Func<object, TViewModel> ViewModel { get; }

        public void Navigate(object? param) 
        {
            NavigationStore.CurrentViewModel = ViewModel(param);
        }
    }
}
