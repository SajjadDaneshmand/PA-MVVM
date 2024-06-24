using PersonalAccounting.Model.Model;
using System.Collections.Generic;


namespace PersonalAccounting.Model.Repositories
{
    public interface ITransactionsRepository
    {
        List<Transactions> GetAllTransactions();
        Transactions GetTransactionById(int id);
        List<Transactions> GetTransactionsByType(int type);
        bool InsertTransaction(Transactions transaction);
        bool UpdateTransaction(Transactions transaction);
        bool DeleteTransaction(Transactions transaction);
        bool DeleteTransaction(int id);
        List<Transactions> GetLargestPaymentTransactions();
        List<Transactions> GetLargestReceiveTransactions();
    }
}
