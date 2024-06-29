using PersonalAccounting.ViewModel.Services.NavigationInterfaces;
using PersonalAccounting.ViewModel.Stores;
using PersonalAccounting.ViewModel.ViewModels;
using PersonalAccounting.ViewModel.ViewModels.IViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Services.NavigationServices
{
    public class HomeNavigationService : IHomeNavigationService
    {
        private readonly IHomeViewModel _homeViewModel;
        private readonly INavigationStore _navigationStore;

        public HomeNavigationService(IHomeViewModel homeViewModel, INavigationStore navigationStore)
        {
            _homeViewModel = homeViewModel;
            _navigationStore = navigationStore;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _homeViewModel;
        }
    }
}
