using PersonalAccounting.ViewModel.Services.NavigationInterfaces;
using PersonalAccounting.ViewModel.Stores;
using PersonalAccounting.ViewModel.ViewModels.IViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Services.NavigationServices
{
    public class SettingsNavigationService: ISettingsNavigationService
    {
        private readonly INavigationStore _navigationStore;
        private readonly ISettingsViewModel _settingsViewModel;

        public SettingsNavigationService(INavigationStore navigationStore, ISettingsViewModel settingsViewModel)
        {
            _navigationStore = navigationStore;
            _settingsViewModel = settingsViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _settingsViewModel;
        }
    }

}
