using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineregistrationAPI.Services
{
    public interface IRegisterDAL<Register>
    {
        public void create(Register r);
        public void deleteuser(string mobile);
        public void editdetail(Register s);

        public Register getbymobile(string mobile);
        public List<Register> getallusers();
    }
}
