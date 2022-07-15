using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankWebAPI.DataModel;
using BankWebAPI.Service;

namespace BankWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        private readonly IAccountservice<BankAccount> db;
        public BankAccountsController(IAccountservice<BankAccount> _db)
        {
            db = _db;
        }
        // GET: api/BankAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankAccount>>> GetBankAccounts()
        {
            return Ok(db.get());
        }

        // GET: api/BankAccounts/5
        [HttpGet("{accno}")]
        public async Task<ActionResult<BankAccount>> GetBankAccount(string accno)
        {

            return Ok(db.getbyacc(accno));
        }

        // PUT: api/BankAccounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutBankAccount(string id, BankAccount bankAccount)
        {
            if (id != bankAccount.AccNo)
            {
                return BadRequest();
            }
            db.update(bankAccount);
            return Ok();
        }

        // POST: api/BankAccounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BankAccount>> PostBankAccount(BankAccount bankAccount)
        {

            db.create(bankAccount);

            return CreatedAtAction("GetBankAccount", new { id = bankAccount.AccNo }, bankAccount);
        }

        // DELETE: api/BankAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankAccount(string id)
        {
            db.delete(id);
            return Ok();
        }

       // private bool BankAccountExists(string id)
        //{
            //return _context.BankAccounts.Any(e => e.AccNo == id);
        //}
    }
}
