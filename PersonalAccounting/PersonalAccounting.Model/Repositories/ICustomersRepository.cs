using PersonalAccounting.Model.Model;
using System.Collections.Generic;


namespace PersonalAccounting.Model.Repositories
{
    public interface ICustomersRepository
    {
        List<Customers> GetAllCustomers();
        Customers GetCustomerById(int customerId);
        bool InsertCustomer(Customers customer);
        bool UpdateCustomer(Customers customer);
        bool DeleteCustomer(Customers customer);
        bool DeleteCustomer(int customerId);
    }
}
