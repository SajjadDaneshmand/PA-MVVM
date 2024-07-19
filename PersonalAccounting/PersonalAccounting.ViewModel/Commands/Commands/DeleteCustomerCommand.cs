using PersonalAccounting.Model.Context;
using PersonalAccounting.ViewModel.Commands.ICommands;
using PersonalAccounting.ViewModel.ViewModels.IViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static PersonalAccounting.ViewModel.Constants;

namespace PersonalAccounting.ViewModel.Commands.Commands
{
    public class DeleteCustomerCommand : BaseCommand, IDeleteCustomerCommand
    {
        private readonly IUnitOfwork _unitOfwork;

        public DeleteCustomerCommand(IUnitOfwork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public IPersonsListViewModel PersonsListViewModelInstance { get; set; }
        public IUnitOfwork UnitOfWork => _unitOfwork;

        public override void Execute(object parameter)
        {
            using (var dbContextTransaction = UnitOfWork.BeginTransaction())
            {
                UnitOfWork.CustomersRepository.DeleteCustomer(PersonsListViewModelInstance.SelectedRow);
                UnitOfWork.Save();
                dbContextTransaction.Commit();

            }

            PersonsListViewModelInstance.RefreshGrid();
        }

        public override bool CanExecute(object parameter)
        {
            if (PersonsListViewModelInstance.SelectedRow == null)
                return false;
            return true;
        }

        public void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PersonsListViewModelInstance.SelectedRow))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
