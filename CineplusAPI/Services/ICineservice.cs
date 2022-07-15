using CineplusAPI.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineplusAPI.Services
{
    public interface ICineservice<Cinema>
    {
        public void create(Cinema c);
        public void update(Cinema c);
        public List<Cinema> get();
        public Cinema getbyid(int id);
        public void delete(int id);
        
    }
}
