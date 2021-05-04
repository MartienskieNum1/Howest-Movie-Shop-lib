using System;
using System.Collections.Generic;

#nullable disable

namespace lib.Library.Models
{
    public partial class Person
    {
        public long Id { get; set; }
        public string ImdbId { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
    }
}
