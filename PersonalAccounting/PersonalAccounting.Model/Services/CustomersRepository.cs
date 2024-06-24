using PersonalAccounting.Model.Model;
using PersonalAccounting.Model.Repositories;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;


namespace PersonalAccounting.Model.Services
{
    public class CustomersRepository : ICustomersRepository
    {
        private Accounting_DBEntities _db;

        public CustomersRepository(Accounting_DBEntities db)
        {
            _db = db;
        }

        public bool DeleteCustomer(Customers customer)
        {
            try
            {
                _db.Entry(customer).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            Customers customer = GetCustomerById(customerId);
            try
            {
                _db.Entry(customer).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Customers> GetAllCustomers()
        {
            return _db.Customers.ToList();
        }

        public Customers GetCustomerById(int customerId)
        {
            return _db.Customers.Find(customerId);
        }

        public bool InsertCustomer(Customers customer)
        {
            try
            {
                _db.Customers.Add(customer);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool UpdateCustomer(Customers customer)
        {
            try
            {
                _db.Entry(customer).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
