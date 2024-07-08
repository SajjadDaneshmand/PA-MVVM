using PersonalAccounting.Model.Context;
using PersonalAccounting.Model.Model;
using PersonalAccounting.ViewModel.ViewModels.IViewModels;
using PersonalAccounting.ViewModel.ViewModels.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.ViewModels.ViewModels
{
    public class PersonsListViewModel: BaseViewModel, IPersonsListViewModel
    {
        private string _searchInput;
        private ObservableCollection<Customers> _personCollection;

        public PersonsListViewModel()
        {
         
        }
        public string SearchInput {
            get => _searchInput;
            set
            {
                _searchInput = value;
                OnPropertyChanged(nameof(SearchInput));
                UpdatePersonList();
            }
        }
        public ObservableCollection<Customers> PersonsCollection {
            get => _personCollection;
            set
            {
                SetField(ref _personCollection, value, nameof(PersonsCollection));
            }
        }

        private void UpdatePersonList()
        {
            using (var db = new UnitOfWork())
            {
                PersonsCollection = db.CustomersRepository.FilterCustomersByNameMobile(SearchInput);
            }
        }


    }
}
