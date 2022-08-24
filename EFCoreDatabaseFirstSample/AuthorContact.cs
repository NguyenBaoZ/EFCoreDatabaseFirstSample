using System;
using System.Collections.Generic;

namespace EFCoreDatabaseFirstSample
{
    public partial class AuthorContact
    {
        public long AuthorId { get; set; }
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; }
        public virtual Author Author { get; set; }
    }
}
