using System;
using System.Collections.Generic;

#nullable disable

namespace lib.Library.Models
{
    public partial class MovieRole
    {
        public int MovieId { get; set; }
        public int PersonId { get; set; }
        public string Role { get; set; }
    }
}
