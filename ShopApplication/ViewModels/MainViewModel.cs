using ShopApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase currentViewModel;

        public ViewModelBase CurrentViewModel 
        {   get => currentViewModel;
            set 
            {
                currentViewModel = value;
            }
        }

        public DataAdapterClient DataAdapterClient { get; }

        public MainViewModel(DataAdapterClient dataAdapterClient)
        {
            DataAdapterClient = dataAdapterClient;
            CurrentViewModel = new ProductsListingViewModel(DataAdapterClient);
        }
    }
}
