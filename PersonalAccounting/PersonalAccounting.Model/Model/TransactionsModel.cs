using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.Model.Model
{
    public class TransactionsModel
    {
        public int TransactionId { get; set; }
        public string FullName { get; set; }
        public Int64 Amount { get; set; }
        public DateTime TrDateTime { get; set; }
        public string Description { get; set; }
    }
}
