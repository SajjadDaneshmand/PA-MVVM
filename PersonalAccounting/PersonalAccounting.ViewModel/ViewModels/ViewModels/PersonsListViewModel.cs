using PersonalAccounting.Model.Context;
using PersonalAccounting.Model.Model;
using PersonalAccounting.ViewModel.ViewModels.IViewModels;
using PersonalAccounting.ViewModel.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.ViewModels.ViewModels
{
    public class PersonsListViewModel: BaseViewModel, IPersonsListViewModel
    {
        public List<Customers> PersonsCollection
        {
            get
            {
                using (var db = new UnitOfWork())
                {
                    return db.CustomersRepository.GetAllCustomers();
                }
            }
        }

    }
}
