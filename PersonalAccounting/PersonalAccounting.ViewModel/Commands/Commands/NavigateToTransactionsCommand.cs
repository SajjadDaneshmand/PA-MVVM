using PersonalAccounting.ViewModel.Commands.ICommands;
using PersonalAccounting.ViewModel.Services.NavigationInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Commands.Commands
{
    public class NavigateToTransactionsCommand : BaseCommand, INavigateToTransactionsCommand
    {
        private readonly ITransactionsNavigationService _transactionNavigationService;

        public NavigateToTransactionsCommand(ITransactionsNavigationService navigationService)
        {
            _transactionNavigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _transactionNavigationService.Navigate();
        }
    }
}
