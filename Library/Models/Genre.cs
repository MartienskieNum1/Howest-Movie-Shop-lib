using System;
using System.Collections.Generic;

#nullable disable

namespace lib.Library.Models
{
    public partial class Genre
    {
        public long Id { get; set; }
        public string ImdbName { get; set; }
        public string Name { get; set; }
    }
}
