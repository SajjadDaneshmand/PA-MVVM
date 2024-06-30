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
    public class NewPersonNavigationService : INewPersonNavigationService
    {
        private readonly IPersonsTabNavigationStore _navigationStore;
        private readonly INewPersonViewModel _newPersonViewModel;

        public NewPersonNavigationService(IPersonsTabNavigationStore navigationStore, INewPersonViewModel newPersonViewModel)
        {
            _navigationStore = navigationStore;
            _newPersonViewModel = newPersonViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _newPersonViewModel;
        }
    }
}
