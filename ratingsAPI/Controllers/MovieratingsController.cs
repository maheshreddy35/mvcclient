using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ratingsAPI.DataModel;
using ratingsAPI.service;

namespace ratingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieratingsController : ControllerBase
    {
        private readonly Iratingservice<Movierating> db;
        public MovieratingsController(Iratingservice<Movierating> _db)
        {
            db = _db;
        }

        

        // GET: api/Movieratings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movierating>>> GetMovieratings()
        {
            return Ok(db.GetAllMovieRatings());
        }

        // GET: api/Movieratings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movierating>> GetMovierating(string id)
        {
            return Ok(db.GetRatingbyMovie(id));
        }

        

        // POST: api/Movieratings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movierating>> PostMovierating(Movierating movierating)
        {
            db.Addrating(movierating);
            return CreatedAtAction("GetMovierating", new { id = movierating.Movie }, movierating);
        }

        // DELETE: api/Movieratings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovierating(string id)
        {
            db.deleteMovie(id);
            return Ok();
        }

        
    }
}
