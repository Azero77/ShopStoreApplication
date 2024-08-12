using ShopApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Stores
{
    public class NavigationStore
    {
        public ViewModelBase _currentViewModel;
		public ViewModelBase CurrentViewModel
		{
			get
			{
				return _currentViewModel;
			}
			set
			{
				_currentViewModel = value;
				OnCurrentViewModelChanged();
			}
		}

		public event Action CurrentViewModelChagned;
		public void OnCurrentViewModelChanged() 
		{
			CurrentViewModelChagned?.Invoke();
		}

    }
}
