using CineplusAPI.DAL;
using CineplusAPI.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineplusAPI.Services
{
    public class Bookingservice : IBookingservice<Booking>
    {
        private readonly IBookingDAL<Booking> db = new BookingDAL();
        public void Addbooking(Booking b)
        {
            db.Addbooking(b);
        }

        public List<Booking> Getbooking()
        {
            return db.Getbooking();
        }

        public void Removebooking(int id)
        {
            db.Removebooking(id);
        }
    }
}
