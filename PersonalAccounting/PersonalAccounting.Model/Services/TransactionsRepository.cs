using PersonalAccounting.Model.Model;
using PersonalAccounting.Model.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using static PersonalAccounting.Model.Utilities.Constants;

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
            try
            {
                _db.Entry(transaction).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteTransaction(int id)
        {
            try
            {
                Transactions transaction = GetTransactionById(id);
                _db.Entry(transaction).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Transactions> GetAllTransactions()
        {
            return _db.Transactions.ToList();
        }

        public List<Transactions> GetLargestPaymentTransactions()
        {
            var paymentTransactions = GetTransactionsByType(PAYMENT_TYPE);
            var maxAmount = paymentTransactions.Max(t => t.Amount);

            return paymentTransactions.Where(t => t.Amount == maxAmount).ToList();
        }

        public List<Transactions> GetLargestReceiveTransactions()
        {
            var receiveTransactions = GetTransactionsByType(RECEIVE_TYPE);
            var maxAmount = receiveTransactions.Max(t => t.Amount);

            return receiveTransactions.Where(t => t.Amount == maxAmount).ToList();
        }


        public Transactions GetTransactionById(int id)
        {
            return _db.Transactions.Find(id);
        }

        public List<Transactions> GetTransactionsByType(int type)
        {
            return _db.Transactions.Where(t => t.TrType == type).ToList();
        }

        public bool InsertTransaction(Transactions transaction)
        {
            try
            {
                _db.Transactions.Add(transaction);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateTransaction(Transactions transaction)
        {
            try
            {
                _db.Entry(transaction).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
