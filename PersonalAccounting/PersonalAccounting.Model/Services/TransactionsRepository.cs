using PersonalAccounting.Model.Model;
using PersonalAccounting.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.Model.Services
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private Accounting_DBEntities _db;

        public TransactionsRepository(Accounting_DBEntities db)
        {
            _db = db;
        }

        public bool DeleteTransaction(Transactions transaction)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTransaction(int id)
        {
            throw new NotImplementedException();
        }

        public List<Transactions> GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        public Transactions GetLargestTransaction()
        {
            throw new NotImplementedException();
        }

        public List<Transactions> GetTransactionsByType(int type)
        {
            throw new NotImplementedException();
        }

        public bool InsertTransaction(Transactions transaction)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateTransaction(Transactions transaction)
        {
            throw new NotImplementedException();
        }
    }
}
