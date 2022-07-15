
using ratingsAPI.DAL;
using ratingsAPI.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ratingsAPI.service
{
    public class Ratingservice : Iratingservice<Movierating>
    {
        
        public readonly IRatingDAL<Movierating> db; 
        public Ratingservice(IRatingDAL<Movierating> db1)
        {
            db = db1;
        }
        public void Addrating(Movierating rate)
        {
            db.Addrating(rate);
        }

        public List<Movierating> GetAllMovieRatings()
        {
            return db.GetAllMovieRatings();
        }

        public Movierating GetRatingbyMovie(string movie)
        {
            return db.GetRatingbyMovie(movie);
        }

        public void deleteMovie(string movie)
        {
            db.deleteMovie(movie);
        }
    }
}
