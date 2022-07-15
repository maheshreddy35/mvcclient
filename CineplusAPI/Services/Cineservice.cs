
using CineplusAPI.DAL;
using CineplusAPI.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineplusAPI.Services
{
    public class Cineservice : ICineservice<Cinema>
    {
        
        private readonly ICineDAL<Cinema> db = new CineDAL();

        
        public void create(Cinema c)
        {
            db.create(c);
        }

        public void delete(int id)
        {
            
            db.delete(id);
        }

        public List<Cinema> get()
        {
            return db.get();
        }

       

        public Cinema getbyid(int id)
        {
            return db.getbyid(id);
        }

       
        public void update(Cinema cinema)
        {
            
            db.update(cinema);
        }
    }
}
