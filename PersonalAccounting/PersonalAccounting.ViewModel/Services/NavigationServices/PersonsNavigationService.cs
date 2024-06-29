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
    public class PersonsNavigationService : IPersonsNavigationService
    {
        private readonly INavigationStore _navigationStore;
        private readonly IPersonsViewModel _personsViewModel;

        public PersonsNavigationService(INavigationStore navigationStore, IPersonsViewModel personsViewModel)
        {
            _navigationStore = navigationStore;
            _personsViewModel = personsViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _personsViewModel;
        }
    }
}
