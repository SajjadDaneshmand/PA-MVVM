using PersonalAccounting.Model.Model;
using PersonalAccounting.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public List<Customers> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Customers GetCustomerById(int customerId)
        {
            throw new NotImplementedException();
        }

        public bool InsertCustomer(Customers customer)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customers customer)
        {
            throw new NotImplementedException();
        }
    }
}
