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
    public class NewTransactionNavigationService : INewTransactionNavigationService
    {
        private readonly INewTransactionViewModel _newTransactionViewModel;
        private readonly ITransactionsTabNavigationStore _transactionsTabNavigationStore;

        public NewTransactionNavigationService(
            INewTransactionViewModel newTransactionViewModel,
            ITransactionsTabNavigationStore transactionsTabNavigationStore)
        {
            _newTransactionViewModel = newTransactionViewModel;
            _transactionsTabNavigationStore = transactionsTabNavigationStore;
        }

        public void Navigate()
        {
            _transactionsTabNavigationStore.CurrentViewModel = _newTransactionViewModel;
        }
    }
}
