using PersonalAccounting.Model.Model;
using PersonalAccounting.Model.Repositories;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System;


namespace PersonalAccounting.Model.Services
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly Accounting_DBEntities _db;

        public CustomersRepository(Accounting_DBEntities db)
        {
            _db = db;
        }

        public bool DeleteCustomer(Customers customer)
        {
            try
            {

                _db.Entry(customer).State = EntityState.Deleted;
                //_db.Customers.Remove(customer);
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
                // _db.Entry(customer).State = EntityState.Deleted;
                DeleteCustomer(customer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ObservableCollection<Customers> GetAllCustomers()
        {

            List<Customers> customerList = _db.Customers.ToList();
            return new ObservableCollection<Customers>(customerList);
        }

        public ObservableCollection<Customers> FilterCustomersByNameMobile(string text)
        {
            var filterPersons = _db.Customers.Where(
                c =>
                c.FullName.Contains(text) ||
                c.Mobile.Contains(text)).ToList();
            return new ObservableCollection<Customers>(filterPersons);
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

        public ObservableCollection<PersonIdModel> GetFullNameId()
        {
            try
            {
                var nameId = _db.Customers.Select(
                    c => new PersonIdModel()
                    {
                        Id = c.CustomerID,
                        FullName = c.FullName
                    }
                    );
                return new ObservableCollection<PersonIdModel>(nameId);
            }
            catch
            {
                return new ObservableCollection<PersonIdModel>();
            }
        }
    }
}
