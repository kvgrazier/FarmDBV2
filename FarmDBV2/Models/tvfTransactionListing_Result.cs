//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FarmDBV2.Models
{
    using System;
    
    public partial class tvfTransactionListing_Result
    {
        public int TransactionID { get; set; }
        public Nullable<int> AcctNumber { get; set; }
        public string AccountName { get; set; }
        public string AcctSubType { get; set; }
        public Nullable<decimal> AcctAmount { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string TransactionDescription { get; set; }
        public Nullable<double> Quantity { get; set; }
        public string AccountPerson { get; set; }
    }
}