using CineregistrationAPI.DataModel;
using CineregistrationAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineregistrationAPI.DAL
{
    public class Registerservice : IRegisterservice<Register>
    {
        public readonly IRegisterDAL<Register> db;
        public Registerservice(IRegisterDAL<Register> _db)
        {
            db = _db;
        }
        public void create(Register r)
        {
            db.create(r);
        }

        public void deleteuser(string mobile)
        {
            db.deleteuser(mobile);
        }

        public void editdetail(Register r)
        {
            db.editdetail(r);
        }

        public List<Register> getallusers()
        {
            return db.getallusers();
        }

        public Register getbymobile(string mobile)
        {
            return db.getbymobile(mobile);
        }
    }
}
