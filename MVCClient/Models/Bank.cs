using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCClient.Models
{
    public class Bank
    {
        [Key]
        public string AccNo { get; set; }
        public string AccHolderName { get; set; }
        public string AccType { get; set; }
        public DateTime? Doj { get; set; }
        public double? Balance { get; set; }
        public string Password { get; set; }
    }
}
