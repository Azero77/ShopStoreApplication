using ShopApplication.Services;
using ShopApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Commands
{
    public class NavigationCommand<TViewModel> : CommandBase
        where TViewModel : ViewModelBase
    {
        public NavigationCommand(NavigationService<ViewModelBase> navigationService)
        {
            NavigationService = navigationService;
        }

        public NavigationService<ViewModelBase> NavigationService { get; }

        public override void Execute(object? parameter)
        {
            NavigationService.Navigate(parameter);
        }
    }
}
