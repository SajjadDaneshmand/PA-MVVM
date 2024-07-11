using PersonalAccounting.Model.Context;
using PersonalAccounting.Model.Model;
using PersonalAccounting.ViewModel.Commands.ICommands;
using PersonalAccounting.ViewModel.ViewModels.IViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Commands.Commands
{
    public class CreateTransactionCommand : BaseCommand, ICreateTransactionCommand
    {
        public INewTransactionViewModel NewTransactionViewModel;

        public override void Execute(object parameter)
        {
            using (var db = new UnitOfWork())
            {

                Transactions transactions = new Transactions()
                {
                    TrType = NewTransactionViewModel.TrType,
                    CustomerID = NewTransactionViewModel.SelectedPerson.Id,
                    Amount = Int64.Parse(NewTransactionViewModel.Amount),
                    Description = NewTransactionViewModel.Description,
                    Date = DateTime.Now,
                };
                db.TransactionsRepository.InsertTransaction(transactions);
                db.Save();
            }

            NewTransactionViewModel.SelectedPerson = null;
            NewTransactionViewModel.Amount = string.Empty;
            NewTransactionViewModel.Description = string.Empty;
        }

        public override bool CanExecute(object parameter)
        {
            if (NewTransactionViewModel.SelectedPerson == null)
                return false;
            if (NewTransactionViewModel.Amount == null || NewTransactionViewModel.Amount.StartsWith("0"))
                return false;

            foreach (char c in NewTransactionViewModel.Amount)
                if (!char.IsDigit(c))
                    return false;

            return true;
        }

        public void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Check if relevant properties have changed and update command availability
            if (
                e.PropertyName == nameof(NewTransactionViewModel.SelectedPerson) ||
                e.PropertyName == nameof(NewTransactionViewModel.Amount)
                )
            {
                OnCanExecuteChanged();
            }
        }
    }
}
