using System;
using System.Collections.Generic;

#nullable disable

namespace CineplusAPI.DataModel
{
    public partial class Cinema
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Theatername { get; set; }
        public string Movie { get; set; }
        public double? Price { get; set; }
        public byte[] Image { get; set; }
    }
}
