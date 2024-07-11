using PersonalAccounting.Model.Repositories;
using PersonalAccounting.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.Model.Context
{
    public interface IUnitOfwork: IDisposable
    {
        ICustomersRepository CustomersRepository { get; }
        ITransactionsRepository TransactionsRepository { get; }
        IUserRepository UserRepository { get; }
        bool Save();
    }
}
