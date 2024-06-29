using PersonalAccounting.ViewModel.Commands.ICommands;
using PersonalAccounting.ViewModel.Services.NavigationInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Commands.Commands
{
    public class NavigateToPersonsCommand : BaseCommand, INavigateToPersonsCommand
    {
        private readonly IPersonsNavigationService _personsNavigationService;

        public NavigateToPersonsCommand(IPersonsNavigationService personsNavigationService)
        {
            _personsNavigationService = personsNavigationService;
        }

        public override void Execute(object parameter)
        {
            _personsNavigationService.Navigate();
        }
    }
}
