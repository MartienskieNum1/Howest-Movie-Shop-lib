using System;
using System.Linq;
using System.Collections.Generic;
using lib.Library.Models;

namespace lib.Library.Services
{
    public class GenreMovieService
    {
        moviesContext context = new moviesContext();

        public IEnumerable<GenreMovie> All()
        {
            return context.GenreMovies
                .OrderBy(genreMovie => genreMovie.MovieId);
        }

        public int GetGenreIdForMovieId(int movieId)
        {
            return context.GenreMovies
                .Where(g => g.MovieId == movieId)
                .Select(g => g.GenreId)
                .FirstOrDefault();
        }
    }
}