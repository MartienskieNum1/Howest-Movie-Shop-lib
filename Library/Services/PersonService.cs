using System;
using System.Linq;
using System.Collections.Generic;
using lib.Library.Models;

namespace lib.Library.Services
{
    public class PersonService
    {
        moviesContext context = new moviesContext();

        public IEnumerable<Person> All()
        {
            return context.Persons
                .OrderBy(person => person.Name);
        }

        public List<string> GetPersonNamesForPersonIds(List<int> ids)
        {
            return context.Persons
                .Where(p => ids.Contains(Convert.ToInt32(p.Id)))
                .Select(p => p.Name)
                .ToList();
        }
    }
}