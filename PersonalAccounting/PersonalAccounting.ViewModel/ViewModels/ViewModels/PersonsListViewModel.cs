using PersonalAccounting.Model.Context;
using PersonalAccounting.Model.Model;
using PersonalAccounting.ViewModel.Commands.ICommands;
using PersonalAccounting.ViewModel.ViewModels.IViewModels;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static PersonalAccounting.ViewModel.Constants;

namespace PersonalAccounting.ViewModel.ViewModels.ViewModels
{
    public class PersonsListViewModel : BaseViewModel, IPersonsListViewModel
    {
        private readonly IUnitOfwork _unitOfwork;
        private string _searchInput;
        private ObservableCollection<Customers> _personCollection;
        private Customers _selectedRow;

        public PersonsListViewModel(IRefreshPersonsGridCommand refreshPersonsGridCommand, IUnitOfwork unitOfwork)
        {
            RefreshPersonsGridCommand = refreshPersonsGridCommand;
            _unitOfwork = unitOfwork;
        }

        public IRefreshPersonsGridCommand RefreshPersonsGridCommand { get; set; }
        public IUnitOfwork UnitOfwork => _unitOfwork;

        public Customers SelectedRow
        {
            get => _selectedRow;
            set
            {
                SetField(ref _selectedRow, value, nameof(SelectedRow));
            }
        }

        public IDeleteCustomerCommand DeleteRow { get; set; }

        public string SearchInput
        {
            get => _searchInput;
            set
            {
                SetField(ref _searchInput, value, nameof(SearchInput));
                UpdatePersonList();
            }
        }
        public ObservableCollection<Customers> PersonsCollection
        {
            get => _personCollection;
            set
            {
                SetField(ref _personCollection, value, nameof(PersonsCollection));
            }
        }

        public void UpdatePersonList()
        {
            using (var dbContextTransaction = UnitOfwork.BeginTransaction())
            {
                PersonsCollection = UnitOfwork.CustomersRepository.FilterCustomersByNameMobile(SearchInput);
                dbContextTransaction.Commit();
            }

        }

        public void RefreshGrid()
        {
            using (var dbContextTransaction = UnitOfwork.BeginTransaction())
            {
                PersonsCollection = UnitOfwork.CustomersRepository.GetAllCustomers();
                dbContextTransaction.Commit();
            }
            SearchInput = string.Empty;

        }
    }
}
