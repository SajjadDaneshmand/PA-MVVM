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

namespace PersonalAccounting.ViewModel.ViewModels.ViewModels
{
    public class PersonsListViewModel : BaseViewModel, IPersonsListViewModel
    {
        private string _searchInput;
        private ObservableCollection<Customers> _personCollection;
        private Customers _selectedRow;

        public PersonsListViewModel(IRefreshPersonsGridCommand refreshPersonsGridCommand)
        {
            RefreshPersonsGridCommand = refreshPersonsGridCommand;
        }

        public IRefreshPersonsGridCommand RefreshPersonsGridCommand {  get; set; }

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
            using (var db = new UnitOfWork())
            {
                PersonsCollection = db.CustomersRepository.FilterCustomersByNameMobile(SearchInput);
            }
        }

        public void RefreshGrid()
        {
            using (var db = new UnitOfWork())
            {
                PersonsCollection = db.CustomersRepository.GetAllCustomers();
                SearchInput = string.Empty;
            }
        }
    }
}
