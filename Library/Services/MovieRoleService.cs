using System;
using System.Linq;
using System.Collections.Generic;
using lib.Library.Models;

namespace lib.Library.Services
{
    public class MovieRoleService
    {
        moviesContext context = new moviesContext();

        public IEnumerable<MovieRole> All()
        {
            return context.MovieRoles
                .OrderBy(movieRole => movieRole.MovieId);
        }

        public List<int> GetPersonIdsForMovieIdAndRole(int movieId, string role)
        {
            return context.MovieRoles
                .Where(r => r.MovieId == movieId && r.Role == role)
                .Select(r => r.PersonId)
                .ToList();
        }
    }
}