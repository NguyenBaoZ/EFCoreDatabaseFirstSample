using System;
using System.Collections.Generic;

namespace EFCoreDatabaseFirstSample
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
