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
    public class PersonsListNavigationService : IPersonsListNavigationService
    {
        private readonly IPersonsTabNavigationStore _tabNavigationStore;
        private readonly IPersonsListViewModel _personsListViewModel;

        public PersonsListNavigationService(IPersonsTabNavigationStore tabNavigationStore, IPersonsListViewModel personsListViewModel)
        {
            _tabNavigationStore = tabNavigationStore;
            _personsListViewModel = personsListViewModel;
        }

        public void Navigate()
        {
            _tabNavigationStore.CurrentViewModel = _personsListViewModel;
        }
    }
}
