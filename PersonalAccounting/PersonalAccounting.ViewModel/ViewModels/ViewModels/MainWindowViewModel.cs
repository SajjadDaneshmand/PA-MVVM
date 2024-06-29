using PersonalAccounting.ViewModel.Commands.ICommands;
using PersonalAccounting.ViewModel.Services.NavigationInterfaces;
using PersonalAccounting.ViewModel.Stores;
using PersonalAccounting.ViewModel.ViewModels.IViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.ViewModels.ViewModels
{
    public class MainWindowViewModel : BaseViewModel, IMainWindowViewModel
    {
        // Store for managing navigation
        private readonly INavigationStore _navigationStore;


        public IBaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainWindowViewModel(
            INavigationStore navigationStore,
            IHomeNavigationService homeNavigationService,
            INavigateToHomeCommand navigateToHomeCommand,
            INavigateToPersonsCommand navigateToPersonsCommand,
            INavigateToTransactionsCommand navigateToTransactionsCommand,
            INavigateToReportsCommnad navigateToReportsCommnad,
            INavigateToSettingsCommand navigateToSettingsCommand)
        {
            _navigationStore = navigationStore;
            NavigateToHomeCommand = navigateToHomeCommand;
            NavigateToPersonsCommand = navigateToPersonsCommand;
            NavigateToTransactionsCommand = navigateToTransactionsCommand;
            NavigateToReportsCommand = navigateToReportsCommnad;
            NavigateToSettingsCommand = navigateToSettingsCommand;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        // Commands
        public INavigateToHomeCommand NavigateToHomeCommand {  get; }
        public INavigateToPersonsCommand NavigateToPersonsCommand { get; }
        public INavigateToTransactionsCommand NavigateToTransactionsCommand { get; }
        public INavigateToReportsCommnad NavigateToReportsCommand { get; }
        public INavigateToSettingsCommand NavigateToSettingsCommand { get; }

    }
}
