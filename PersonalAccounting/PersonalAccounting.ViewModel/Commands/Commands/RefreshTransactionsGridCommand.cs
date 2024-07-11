using PersonalAccounting.ViewModel.Commands.ICommands;
using PersonalAccounting.ViewModel.ViewModels.IViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Commands.Commands
{
    public class RefreshTransactionsGridCommand : BaseCommand, IRefreshTransactionsGridCommand
    {
        public ITransactionsListViewModel TransactionsListViewModel;
        public override void Execute(object parameter)
        {
            TransactionsListViewModel.RefreshTrDataGrid();
        }
    }
}
