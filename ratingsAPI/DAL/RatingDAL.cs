using ratingsAPI.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ratingsAPI.DAL
{
    public class RatingDAL : IRatingDAL<Movierating>
    {
        public TheatersContext _context;
        public RatingDAL(TheatersContext db)
        {
            _context = db;
        }
        public void Addrating(Movierating rate)
        {
            var res = _context.Movieratings.Find(rate.Movie);
            if (res == null)
            {
                _context.Movieratings.Add(rate);
            }
            else
            {
                _context.Remove(res);
                rate.Rating = (res.Rating + rate.Rating) / 2;
                _context.Movieratings.Add(rate);
            }
            
            _context.SaveChanges();
        }

        public void deleteMovie(string movie)
        {
            var res = _context.Movieratings.Find(movie);
            _context.Movieratings.Remove(res);
            _context.SaveChanges();
        }

        public List<Movierating> GetAllMovieRatings()
        {
           return _context.Movieratings.OrderByDescending(i=>i.Rating).ToList();
        }

        public Movierating GetRatingbyMovie(string movie)
        {
            return _context.Movieratings.Find(movie);
            
        }
    }
}
