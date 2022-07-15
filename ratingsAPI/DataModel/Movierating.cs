using System;
using System.Collections.Generic;

#nullable disable

namespace ratingsAPI.DataModel
{
    public partial class Movierating
    {
        public string Movie { get; set; }
        public double? Rating { get; set; }
        public byte[] Image { get; set; }
    }
}
