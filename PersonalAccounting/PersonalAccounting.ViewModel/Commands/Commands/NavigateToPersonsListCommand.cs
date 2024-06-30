using PersonalAccounting.ViewModel.Services.NavigationServices;
using PersonalAccounting.ViewModel.Commands.ICommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalAccounting.ViewModel.Services.NavigationInterfaces;

namespace PersonalAccounting.ViewModel.Commands.Commands
{
    public class NavigateToPersonsListCommand : BaseCommand, INavigateToPersonsListCommand
    {
        private readonly IPersonsListNavigationService _personsListNavigationService;

        public NavigateToPersonsListCommand(IPersonsListNavigationService personsListNavigationService)
        {
            _personsListNavigationService = personsListNavigationService;
        }

        public override void Execute(object parameter)
        {
            _personsListNavigationService.Navigate();
        }
    }
}
