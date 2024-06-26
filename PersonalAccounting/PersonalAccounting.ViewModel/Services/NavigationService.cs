using PersonalAccounting.ViewModel.ViewModels;
using PersonalAccounting.ViewModel.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Services
{
    public class NavigationService : INavigationService
    {
        private INavigationStore _navigationStore;
        private IBaseViewModel _createViewModel;

        public NavigationService(INavigationStore navigationStore, IBaseViewModel createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel;
        }
    }
}
