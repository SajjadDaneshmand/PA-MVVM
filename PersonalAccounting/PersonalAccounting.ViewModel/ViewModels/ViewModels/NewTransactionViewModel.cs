using PersonalAccounting.Model.Context;
using PersonalAccounting.Model.Model;
using PersonalAccounting.ViewModel.Commands.ICommands;
using PersonalAccounting.ViewModel.ViewModels.IViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

using static PersonalAccounting.ViewModel.Constants;

namespace PersonalAccounting.ViewModel.ViewModels.ViewModels
{
    public class NewTransactionViewModel : BaseViewModel, INewTransactionViewModel
    {
        private readonly IUnitOfwork _unitOfwork;
        private ObservableCollection<PersonIdModel> _persons;
        private PersonIdModel _selectedPerson;
        private string _amount;
        private string _description;

        private bool _receive = false;
        private bool _payment = true;

        public NewTransactionViewModel(ICreateTransactionCommand createTransactionCommand, IUnitOfwork unitOfwork)
        {
            CreateTransaction = createTransactionCommand;
            _unitOfwork = unitOfwork;
        }

        public ICreateTransactionCommand CreateTransaction { get; set; }
        public IUnitOfwork UnitOfWork => _unitOfwork;

        public bool Receive
        {
            get => _receive;
            set
            {
                SetField(ref _receive, value, nameof(Receive));
                SetField(ref _payment, false, nameof(Payment));
            }
        }
        public bool Payment
        {
            get => _payment;
            set
            {
                SetField(ref _payment, value, nameof(Payment));
                SetField(ref _receive, false, nameof(Receive));
            }
        }

        public int TrType
        {
            get
            {
                if (Receive)
                    return 1;
                return 2;
            }
        }

        public ObservableCollection<PersonIdModel> Persons
        {
            get
            {
                if (_persons == null)
                {
                    UpdateComboBox();
                }
                return _persons;
            }
            set => SetField(ref _persons, value, nameof(Persons));
        }

        public PersonIdModel SelectedPerson
        {
            get => _selectedPerson;
            set => SetField(ref _selectedPerson, value, nameof(SelectedPerson));
        }

        public string Amount
        {
            get => _amount;
            set => SetField(ref _amount, value, nameof(Amount));
        }

        public string Description
        {
            get => _description;
            set => SetField(ref _description, value, nameof(Description));
        }



        public void UpdateComboBox()
        {
            using (var dbContextTransaction = UnitOfWork.BeginTransaction())
            {
                Persons = UnitOfWork.CustomersRepository.GetFullNameId();
                dbContextTransaction.Commit();
            }

        }
    }
}
