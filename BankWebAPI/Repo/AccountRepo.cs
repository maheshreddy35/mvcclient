using BankWebAPI.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repo
{
    public class AccountRepo : IAccountRepo<BankAccount>
    {
        public readonly EurofinsDBContext db;
        public AccountRepo(EurofinsDBContext _db)
        {
            db = _db;
        }
        public void create(BankAccount b)
        {
            db.BankAccounts.Add(b);
            db.SaveChanges();
        }

        public void delete(BankAccount b)
        {
            db.BankAccounts.Remove(b);
            db.SaveChanges();
        }

        public void delete(string accno)
        {
            var res = db.BankAccounts.Find(accno);
            db.BankAccounts.Remove(res);
            db.SaveChanges();
        }

        public List<BankAccount> get()
        {
            return db.BankAccounts.ToList();
        }

        public BankAccount getbyacc(string accno)
        {
            return db.BankAccounts.Find(accno);
        }

        public void update(BankAccount b)
        {
            db.BankAccounts.Update(b);
            db.SaveChanges();
        }
    }
}
