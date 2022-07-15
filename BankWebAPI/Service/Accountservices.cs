using BankWebAPI.DataModel;
using BankWebAPI.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace BankWebAPI.Service
{
    public class Accountservices:IAccountservice<BankAccount>
    {
        public readonly IAccountRepo<BankAccount> bank;
        public Accountservices(IAccountRepo<BankAccount> db) 
        {
            bank = db;
        }

        public void create(BankAccount b)
        {
            bank.create(b);
        }

        public void update(BankAccount b)
        {
            bank.update(b);
        }

        public List<BankAccount> get()
        {
            return bank.get();
        }

        public BankAccount getbyacc(string accno)
        {
            return bank.getbyacc(accno);
        }

        public void delete(string accno)
        {
            bank.delete(accno);
        }

       
    }
}
