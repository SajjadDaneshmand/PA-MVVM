using PersonalAccounting.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.Model.Repositories
{
    public interface ITransactionsRepository
    {
        List<Transactions> GetAllTransactions();
        List<Transactions> GetTransactionsByType(int type);
        bool InsertTransaction(Transactions transaction);
        bool UpdateTransaction(Transactions transaction);
        bool DeleteTransaction(Transactions transaction);
        bool DeleteTransaction(int id);
        Transactions GetLargestTransaction();
        void Save();
    }
}
