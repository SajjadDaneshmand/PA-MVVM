using PersonalAccounting.Model.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.ViewModels.IViewModels
{
    public interface ITransactionsListViewModel: IBaseViewModel
    {
        string StartDate { get; set; }
        ObservableCollection<TransactionsModel> TransactionsCollection { get; set; }
        void RefreshTrDataGrid();
    }
}
