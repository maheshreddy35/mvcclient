using CineplusAPI.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineplusAPI.DAL
{
   
    public class CineDAL : ICineDAL<Cinema>
    {
        private TheatersContext db = new TheatersContext();

        

        public void create(Cinema c)
        {
            db.Cinemas.Add(c);
            db.SaveChanges();
        }

        public void delete(int id)
        {
            var c = db.Cinemas.Find(id);
            db.Cinemas.Remove(c);
            db.SaveChanges();
        }

        public List<Cinema> get()
        {
            return db.Cinemas.ToList();
        }

       

        public Cinema getbyid(int id)
        {
            return db.Cinemas.Find(id);
        }

        

        public void update(Cinema c)
        {
            db.Cinemas.Update(c);
            db.SaveChanges();
        }
    }
}
