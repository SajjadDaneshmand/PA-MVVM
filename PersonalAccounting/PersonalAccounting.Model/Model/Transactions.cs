//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonalAccounting.Model.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transactions
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int TrType { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual AccountingTypes AccountingTypes { get; set; }
        public virtual Customers Customers { get; set; }
    }
}
