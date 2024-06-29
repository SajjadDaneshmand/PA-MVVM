using PersonalAccounting.ViewModel.Commands.ICommands;
using PersonalAccounting.ViewModel.Services.NavigationInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Commands.Commands
{
    public class NavigateToNewPersonCommand : BaseCommand, INavigateToNewPersonCommand
    {
        private readonly INewPersonNavigationService _newPersonNavigationService;

        public NavigateToNewPersonCommand(INewPersonNavigationService newPersonNavigationService)
        {
            _newPersonNavigationService = newPersonNavigationService;
        }

        public override void Execute(object parameter)
        {
            _newPersonNavigationService.Navigate();
        }
    }
}
