using PersonalAccounting.ViewModel.Commands.ICommands;
using PersonalAccounting.ViewModel.Services.NavigationInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Commands.Commands
{
    public class NavigateToHomeCommand : BaseCommand, INavigateToHomeCommand
    {
        private readonly IHomeNavigationService _homeNavigationService;

        public NavigateToHomeCommand(IHomeNavigationService homeNavigationService)
        {
            _homeNavigationService = homeNavigationService;
        }

        public override void Execute(object parameter)
        {
            _homeNavigationService.Navigate();
        }
    }
}
