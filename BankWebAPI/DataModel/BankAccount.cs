using System;
using System.Collections.Generic;

#nullable disable

namespace BankWebAPI.DataModel
{
    public partial class BankAccount
    {
        public string AccNo { get; set; }
        public string AccHolderName { get; set; }
        public string AccType { get; set; }
        public DateTime? Doj { get; set; }
        public double? Balance { get; set; }
        public string Password { get; set; }
        public string Phno { get; set; }
    }
}
