using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineregistrationAPI.DataModel;
using CineregistrationAPI.DAL;

namespace CineregistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly IRegisterservice<Register> db;
        public RegistersController(IRegisterservice<Register> _db)
        {
            db = _db;
        }

       
        // GET: api/Registers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Register>>> GetRegisters()
        {
            return Ok(db.getallusers());
        }

        // GET: api/Registers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Register>> GetRegister(string id)
        {
            var res = db.getbymobile(id);
            if(res==null)
            {
                return NotFound();
            }
            return res;

        }

        // PUT: api/Registers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegister(string id, Register register)
        {
            db.editdetail(register);
            return Ok();
        }

        // POST: api/Registers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Register>> PostRegister(Register register)
        {
            db.create(register);

            return CreatedAtAction("GetRegister", new { id = register.Phoneno }, register);
        }

        // DELETE: api/Registers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegister(string id)
        {
            db.deleteuser(id);
            return Ok();
        }

        
    }
}
