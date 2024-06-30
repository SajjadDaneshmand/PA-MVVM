using PersonalAccounting.ViewModel.Commands.ICommands;
using PersonalAccounting.ViewModel.Services.NavigationInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Commands.Commands
{
    public class NavigateToTransactionsListCommand : BaseCommand, INavigateToTransactionsListCommand
    {
        private readonly ITransactionsListNavigationService _transactionsListNavigationService;

        public NavigateToTransactionsListCommand(ITransactionsListNavigationService transactionsListNavigationService)
        {
            _transactionsListNavigationService = transactionsListNavigationService;
        }

        public override void Execute(object parameter)
        {
            _transactionsListNavigationService.Navigate();
        }
    }
}
