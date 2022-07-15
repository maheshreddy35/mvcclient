using System;
using System.Collections.Generic;

#nullable disable

namespace BankWebAPI.DataModel
{
    public partial class Transaction
    {
        public int TransId { get; set; }
        public DateTime? TransDate { get; set; }
        public double? Amt { get; set; }
        public string AccNo { get; set; }
        public string TransType { get; set; }
        public double? Balance { get; set; }
    }
}
