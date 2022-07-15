using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCClient.Models
{
    public class Transactions
    {
        public int TransId { get; set; }
        public DateTime? TransDate { get; set; }
        public double? Amt { get; set; }
        public string AccNo { get; set; }
        public string TransType { get; set; }
        public double? Balance { get; set; }
    }
}
