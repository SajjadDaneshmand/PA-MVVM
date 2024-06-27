using PersonalAccounting.ViewModel.Services.NavigationInterfaces;
using PersonalAccounting.ViewModel.Stores;
using PersonalAccounting.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Services.NavigationServices
{
    public class HomeNavigationService : IHomeNavigationService
    {
        IBaseViewModel _targetViewModel;
        INavigationStore _navigationStore;

        public HomeNavigationService(IBaseViewModel targetViewModel, INavigationStore navigationStore)
        {
            _targetViewModel = targetViewModel;
            _navigationStore = navigationStore;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _targetViewModel;
        }
    }
}
