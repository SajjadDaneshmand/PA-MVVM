using PersonalAccounting.ViewModel.Commands.ICommands;
using PersonalAccounting.ViewModel.ViewModels.IViewModels;
using static PersonalAccounting.ViewModel.Utilities.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalAccounting.Model.Repositories;
using PersonalAccounting.Model.Model;
using PersonalAccounting.Model.Context;

using static PersonalAccounting.ViewModel.Constants;

namespace PersonalAccounting.ViewModel.Commands.Commands
{
    public class CreateCustomerCommand : BaseCommand, ICreateCustomerCommand
    {
        private readonly IUnitOfwork _unitOfwork;

        public CreateCustomerCommand(IUnitOfwork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public IUnitOfwork UnitOfWork => _unitOfwork;

        public INewPersonViewModel NewPersonViewModelInstance;
        public IPersonsListViewModel PersonsListViewModelInstance;
        public INewTransactionViewModel NewTransactionViewModelInstance;

        public override void Execute(object parameter)
        {
            Customers customer = new Customers
            {
                FullName = NewPersonViewModelInstance.FullName?.Trim(),
                Mobile = NewPersonViewModelInstance.PhoneNumber?.Trim(),
                Email = NewPersonViewModelInstance.Email?.Trim(),
                Address = NewPersonViewModelInstance.Address?.Trim()
            };

            try
            {
                using (var dbContextTransaction = UnitOfWork.BeginTransaction())
                {
                    UnitOfWork.CustomersRepository.InsertCustomer(customer);
                    UnitOfWork.Save();
                    dbContextTransaction.Commit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            NewPersonViewModelInstance.FullName = string.Empty;
            NewPersonViewModelInstance.PhoneNumber = string.Empty;
            NewPersonViewModelInstance.Email = string.Empty;
            NewPersonViewModelInstance.Address = string.Empty;

            NewTransactionViewModelInstance.UpdateComboBox();
            PersonsListViewModelInstance.RefreshGrid();
        }

        public void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Check if relevant properties have changed and update command availability
            if (e.PropertyName == nameof(NewPersonViewModelInstance.FullName) ||
                e.PropertyName == nameof(NewPersonViewModelInstance.PhoneNumber) ||
                e.PropertyName == nameof(NewPersonViewModelInstance.Email)
               )
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            // check full name could not be null
            if (string.IsNullOrEmpty(NewPersonViewModelInstance.FullName))
            {
                return false;
            }

            // check if phonenumber and email are not null, it should be valid
            if (
                !string.IsNullOrEmpty(NewPersonViewModelInstance.PhoneNumber) &&
                !string.IsNullOrEmpty(NewPersonViewModelInstance.Email)
                )
            {
                return IsValidPhoneNumber(NewPersonViewModelInstance.PhoneNumber) &&
                       IsValidEmail(NewPersonViewModelInstance.Email);
            }

            // check if only phone number isn't null and email is null
            if (!string.IsNullOrEmpty(NewPersonViewModelInstance.PhoneNumber))
            {
                return IsValidPhoneNumber(NewPersonViewModelInstance.PhoneNumber);
            }

            // check if only email isn't null and phonenumber is null
            if (!string.IsNullOrEmpty(NewPersonViewModelInstance.Email))
            {
                return IsValidEmail(NewPersonViewModelInstance.Email);
            }

            return true;
        }
    }
}
