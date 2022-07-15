using CineregistrationAPI.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineregistrationAPI.Services
{
    public class RegisterDAL : IRegisterDAL<Register>
    {
        public TheatersContext _context ;
        public RegisterDAL(TheatersContext db)
        {
            _context = db;
        }
        public void create(Register r)
        {
            
                _context.Registers.Add(r);
                _context.SaveChanges();
            
            
        }

        public void deleteuser(string mobile)
        {
            var res = _context.Registers.Find(mobile);
            _context.Registers.Remove(res);
            _context.SaveChanges();
        }

        public void editdetail(Register res)
        {
            
            _context.Registers.Update(res);
            _context.SaveChanges();
        }

        public List<Register> getallusers()
        {
            return _context.Registers.ToList();
        }

        public Register getbymobile(string mobile)
        {
            return _context.Registers.Find(mobile);
        }
    }
}
