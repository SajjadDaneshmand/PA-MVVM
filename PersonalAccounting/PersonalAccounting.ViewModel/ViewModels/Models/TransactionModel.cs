using PersonalAccounting.ViewModel.ViewModels.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.ViewModels.Models
{
    public class TransactionModel : BaseViewModel, ITransactionModel
    {
        public int TransactionId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FullName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long Amount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string TrDateTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
