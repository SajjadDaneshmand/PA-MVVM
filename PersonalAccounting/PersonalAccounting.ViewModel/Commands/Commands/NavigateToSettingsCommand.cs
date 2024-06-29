using PersonalAccounting.ViewModel.Commands.ICommands;
using PersonalAccounting.ViewModel.Services.NavigationInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Commands.Commands
{
    public class NavigateToSettingsCommand : BaseCommand, INavigateToSettingsCommand
    {
        private readonly ISettingsNavigationService _settingsNavigationService;

        public NavigateToSettingsCommand(ISettingsNavigationService settingsNavigationService)
        {
            _settingsNavigationService = settingsNavigationService;
        }

        public override void Execute(object parameter)
        {
            _settingsNavigationService.Navigate();
        }
    }
}
