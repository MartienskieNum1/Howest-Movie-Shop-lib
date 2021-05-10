using System;
using System.Linq;
using System.Collections.Generic;
using lib.Library.Models;

namespace lib.Library.Services
{
    public class GenreService
    {
        moviesContext context = new moviesContext();

        public IEnumerable<Genre> All()
        {
            return context.Genres
                .OrderBy(genre => genre.Name);
        }

        public string GetGenreForGenreId(int id)
        {
            return context.Genres
                .Where(g => g.Id == id)
                .Select(g => g.Name)
                .First();
        }
    }
}