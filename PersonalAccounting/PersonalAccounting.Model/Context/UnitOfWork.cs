using PersonalAccounting.Model.Model;
using PersonalAccounting.Model.Repositories;
using PersonalAccounting.Model.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.Model.Context
{
    public class UnitOfWork: IDisposable
    {
        private Accounting_DBEntities _db = new Accounting_DBEntities();

        private ICustomersRepository _customersRepository;
        private ITransactionsRepository _transactionsRepository;
        private IUserRepository _userRepository;

        public ICustomersRepository CustomersRepository => _customersRepository ?? (_customersRepository = new CustomersRepository(_db));
        public ITransactionsRepository TransactionsRepository => _transactionsRepository ?? (_transactionsRepository= new TransactionsRepository(_db));
        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(_db));

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
