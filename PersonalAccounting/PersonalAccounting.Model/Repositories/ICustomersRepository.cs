using PersonalAccounting.Model.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace PersonalAccounting.Model.Repositories
{
    public interface ICustomersRepository
    {
        ObservableCollection<Customers> GetAllCustomers();
        Customers GetCustomerById(int customerId);
        ObservableCollection<Customers> FilterCustomersByNameMobile(string text);
        bool InsertCustomer(Customers customer);
        bool UpdateCustomer(Customers customer);
        bool DeleteCustomer(Customers customer);
        bool DeleteCustomer(int customerId);
        ObservableCollection<PersonIdModel> GetFullNameId();
    }
}
