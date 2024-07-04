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
    public class TransactionsViewModel: BaseViewModel, ITransactionsViewModel
    {
        private readonly ITransactionsTabNavigationStore _transactionsTabNavigationStore;
        public IBaseViewModel CurrentViewModel => _transactionsTabNavigationStore.CurrentViewModel;


        public TransactionsViewModel(
            INavigateToNewTransactionCommand navigateToNewTransactionCommand,
            INavigateToTransactionsListCommand navigateToTransactionsListCommand,
            ITransactionsTabNavigationStore transactionsTabNavigationStore
            )
        {
            NavigateToNewTransactionCommand = navigateToNewTransactionCommand;
            NavigateToTransactionsListCommand = navigateToTransactionsListCommand;
            _transactionsTabNavigationStore = transactionsTabNavigationStore;

            _transactionsTabNavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public INavigateToNewTransactionCommand NavigateToNewTransactionCommand { get; }
        public INavigateToTransactionsListCommand NavigateToTransactionsListCommand { get; }
    }
}
