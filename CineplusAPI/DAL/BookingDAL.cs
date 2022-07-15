using CineplusAPI.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineplusAPI.DAL
{
    public class BookingDAL : IBookingDAL<Booking>
    {
        private readonly TheatersContext db=new TheatersContext();

        public void Addbooking(Booking b)
        {
            var res = db.Bookings.Max(c => c.Id);
            b.Id = res + 1;
            
            db.Bookings.Add(b);
            db.SaveChanges();
        }

        public List<Booking> Getbooking()
        {
            List<Booking> res = db.Bookings.ToList();
            return res;
        }
        public void Removebooking(int id)
        {
            var res = db.Bookings.Find(id);
            db.Bookings.Remove(res);
            db.SaveChanges();
        }
    }
}
