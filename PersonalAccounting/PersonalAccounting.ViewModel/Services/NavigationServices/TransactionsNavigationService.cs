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
    public class TransactionsNavigationService: ITransactionsNavigationService
    {
        private readonly INavigationStore _navigationStore;
        private readonly ITransactionsViewModel _transactionsViewModel;

        public TransactionsNavigationService(INavigationStore navigationStore, ITransactionsViewModel transactionsViewModel)
        {
            _navigationStore = navigationStore;
            _transactionsViewModel = transactionsViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _transactionsViewModel;
        }
    }
}
