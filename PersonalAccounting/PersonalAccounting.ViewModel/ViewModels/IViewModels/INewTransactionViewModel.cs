using PersonalAccounting.Model.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.ViewModels.IViewModels
{
    public interface INewTransactionViewModel: IBaseViewModel
    {
        bool Receive {  get; set; }
        bool Payment { get; set; }
        int TrType { get; }
        ObservableCollection<PersonIdModel> Persons { get; set; }
        PersonIdModel SelectedPerson { get; set; }
        string Amount { get; set; }
        string Description { get; set; }
        void UpdateComboBox();
    }
}
