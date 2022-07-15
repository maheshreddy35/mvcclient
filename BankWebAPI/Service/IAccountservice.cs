using BankWebAPI.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service
{
    public interface IAccountservice<BankAccount>
    {
        public void create(BankAccount b);
        public void update(BankAccount b);
        public List<BankAccount> get();
        public BankAccount getbyacc(string accno);
        public void delete(string accno);
    }
}
