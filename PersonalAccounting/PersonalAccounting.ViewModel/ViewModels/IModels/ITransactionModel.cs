using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.ViewModels.IModels
{
    public interface ITransactionModel: IBaseViewModel
    {
        int TransactionId { get; set; }
        string FullName { get; set; }
        Int64 Amount { get; set; }
        string TrDateTime { get; set; }
        string Description { get; set; }
    }
}
