﻿using PersonalAccounting.Model.Context;
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
    public class DeleteCustomerCommand : BaseCommand, IDeleteCustomerCommand
    {
        public IPersonsListViewModel PersonsListViewModelInstance { get; set; }

        public override void Execute(object parameter)
        {
            using (var db = new UnitOfWork())
            {
                db.CustomersRepository.DeleteCustomer(PersonsListViewModelInstance.SelectedRow);
                db.Save();
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