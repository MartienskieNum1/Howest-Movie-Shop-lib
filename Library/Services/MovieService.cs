using System;
using System.Linq;
using System.Collections.Generic;
using lib.Library.Models;

namespace lib.Library.Services
{
    public class MovieService
    {
        moviesContext context = new moviesContext();

        public IEnumerable<Movie> All()
        {
            return context.Movies
                .OrderBy(movie => movie.Title);
        }

        public Movie GetMovieForMovieId(int movieId)
        {
            return context.Movies
                .Where(m => m.Id == movieId)
                .First();
        }
    }
}