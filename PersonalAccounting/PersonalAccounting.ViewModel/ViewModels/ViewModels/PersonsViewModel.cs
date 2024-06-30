using PersonalAccounting.ViewModel.Commands.ICommands;
using PersonalAccounting.ViewModel.Stores;
using PersonalAccounting.ViewModel.ViewModels.IViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.ViewModels.ViewModels
{
    public class PersonsViewModel: BaseViewModel, IPersonsViewModel
    {
        private readonly IPersonsTabNavigationStore _personsTabNavigationStore;
        public IBaseViewModel CurrentViewModel => _personsTabNavigationStore.CurrentViewModel;
        

        public PersonsViewModel(
            INavigateToNewPersonCommand navigateToNewPersonCommand,
            INavigateToPersonsListCommand navigateToPersonsListCommand,
            IPersonsTabNavigationStore personsTabNavigationStore
            )
        {
            NavigateToNewPersonCommand = navigateToNewPersonCommand;
            NavigateToPersonsListCommand = navigateToPersonsListCommand;
            _personsTabNavigationStore = personsTabNavigationStore;

            _personsTabNavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public INavigateToNewPersonCommand NavigateToNewPersonCommand { get; }
        public INavigateToPersonsListCommand NavigateToPersonsListCommand { get; }
    }
}
