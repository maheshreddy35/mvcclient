using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ratingsAPI.service
{
    public interface Iratingservice<Movierating>
    {
        public void Addrating(Movierating rate);
        public List<Movierating> GetAllMovieRatings();
        public Movierating GetRatingbyMovie(string movie);
        public void deleteMovie(string movie);

    }
}
