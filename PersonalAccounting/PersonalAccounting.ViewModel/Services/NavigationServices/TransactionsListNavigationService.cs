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
    public class TransactionsListNavigationService : ITransactionsListNavigationService
    {
        private readonly ITransactionsTabNavigationStore _transactionsTabNavigationStore;
        private readonly ITransactionsListViewModel _transactionsListViewModel;

        public TransactionsListNavigationService(
            ITransactionsTabNavigationStore transactionsTabNavigationStore,
            ITransactionsListViewModel transactionsListViewModel)
        {
            _transactionsTabNavigationStore = transactionsTabNavigationStore;
            _transactionsListViewModel = transactionsListViewModel;
        }

        public void Navigate()
        {
            _transactionsTabNavigationStore.CurrentViewModel = _transactionsListViewModel;
        }
    }
}
