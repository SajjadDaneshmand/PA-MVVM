using PersonalAccounting.Model.Model;
using PersonalAccounting.Model.Repositories;
using PersonalAccounting.Model.Services;
using System;
using System.Data.Entity;


namespace PersonalAccounting.Model.Context
{
    public class UnitOfWork: IUnitOfwork, IDisposable
    {
        private readonly Accounting_DBEntities _db;

        public UnitOfWork(string connectionString)
        {
            _db = new Accounting_DBEntities(connectionString);
        }

        private ICustomersRepository _customersRepository;
        private ITransactionsRepository _transactionsRepository;
        private IUserRepository _userRepository;

        public ICustomersRepository CustomersRepository => _customersRepository ?? (_customersRepository = new CustomersRepository(_db));
        public ITransactionsRepository TransactionsRepository => _transactionsRepository ?? (_transactionsRepository= new TransactionsRepository(_db));
        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(_db));

        public bool Save()
        {
            try
            {
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public void Dispose()
        {
            _db?.Dispose();
        }

        public DbContextTransaction BeginTransaction()
        {
            return _db.Database.BeginTransaction();
        }
    }
}
