using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineplusAPI.DataModel;
using CineplusAPI.Services;

namespace CineplusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemasController : ControllerBase
    {

        public readonly ICineservice<Cinema> db = new Cineservice();
        // GET: api/Cinemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cinema>>> GetCinemas()
        {
            return Ok(db.get());
        }

        // GET: api/Cinemas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cinema>> GetCinema(int id)
        {
            return db.getbyid(id);
        }

        // PUT: api/Cinemas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCinema(int id, Cinema cinema)
        {
            db.update(cinema);
            return Ok();
        }

        // POST: api/Cinemas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cinema>> PostCinema(Cinema cinema)
        {
            db.create(cinema);

            return CreatedAtAction("GetCinema", new { id = cinema.Id }, cinema);
        }

        // DELETE: api/Cinemas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCinema(int id)
        {
            db.delete(id);
            return Ok();
        }

        
    }
}
