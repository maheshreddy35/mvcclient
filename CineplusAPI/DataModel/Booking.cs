using System;
using System.Collections.Generic;

#nullable disable

namespace CineplusAPI.DataModel
{
    public partial class Booking
    {
        public int Id { get; set; }
        public string Movie { get; set; }
        public string Theater { get; set; }
        public string City { get; set; }
        public double? Price { get; set; }
        public DateTime? Time { get; set; }
        public string Phno { get; set; }
        public int? NoOfTickets { get; set; }
        public byte[] Image { get; set; }
    }
}
