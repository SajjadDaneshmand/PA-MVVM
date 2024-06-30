using PersonalAccounting.ViewModel.Commands.ICommands;
using PersonalAccounting.ViewModel.Services.NavigationInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Commands.Commands
{
    public class NavigateToNewTransactionCommand : BaseCommand, INavigateToNewTransactionCommand
    {
        private readonly INewTransactionNavigationService _newTransactionNavigationService;

        public NavigateToNewTransactionCommand(INewTransactionNavigationService newTransactionNavigationService)
        {
            _newTransactionNavigationService = newTransactionNavigationService;
        }

        public override void Execute(object parameter)
        {
            _newTransactionNavigationService.Navigate();
        }
    }
}
