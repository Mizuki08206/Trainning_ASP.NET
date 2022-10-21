using System;
using System.Collections.Generic;

namespace practice_ASP.Models
{
    public partial class Unext
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string? Who { get; set; }
    }
}
