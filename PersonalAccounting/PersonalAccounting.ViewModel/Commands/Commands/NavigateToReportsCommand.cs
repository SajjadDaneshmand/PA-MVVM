using PersonalAccounting.ViewModel.Commands.ICommands;
using PersonalAccounting.ViewModel.Services.NavigationInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Commands.Commands
{
    public class NavigateToReportsCommand : BaseCommand, INavigateToReportsCommnad
    {
        private readonly IReportsNavigationService _reportsNavigationService;

        public NavigateToReportsCommand(IReportsNavigationService reportsNavigationService)
        {
            _reportsNavigationService = reportsNavigationService;
        }

        public override void Execute(object parameter)
        {
            _reportsNavigationService.Navigate();
        }
    }
}
