using PersonalAccounting.ViewModel.Commands.ICommands;
using PersonalAccounting.ViewModel.ViewModels.IViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.ViewModels.ViewModels
{
    public class NewPersonViewModel : BaseViewModel, INewPersonViewModel
    {
        private string _id;
        private string _fullName;
        private string _phoneNumber;
        private string _email;
        private string _address;

        public NewPersonViewModel(
            INavigateToPersonsListCommand navigateToPersonsListCommand,
            ICreateCustomerCommand createCustomerCommand,
            ICreateCustomerAndNavigateToPersonsListCommand createCustomerAndNavigateToPersonsListCommand
            )
        {
            NavigateToPersonsList = navigateToPersonsListCommand;
            CreateCustomerCommand = createCustomerCommand;
            CreateCustomerAndNavigateToPersonsListCommand = createCustomerAndNavigateToPersonsListCommand;
        }

        public INavigateToPersonsListCommand NavigateToPersonsList { get; }
        public ICreateCustomerCommand CreateCustomerCommand { get; }
        public ICreateCustomerAndNavigateToPersonsListCommand CreateCustomerAndNavigateToPersonsListCommand { get; }

        public string FullName
        {
            get => _fullName;
            set => SetField(ref _fullName, value);
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetField(ref _phoneNumber, value);
        }

        public string Email
        {
            get => _email; 
            set => SetField(ref _email, value);
        }

        public string Address
        {
            get => _address; 
            set => SetField(ref _address, value);
        }

    }
}
