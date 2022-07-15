using CineplusAPI.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineplusAPI.Services
{
    public interface IBookingservice<Booking>
    {
        public void Addbooking(Booking b);
        public void Removebooking(int id);
        public List<Booking> Getbooking();
    }
}
