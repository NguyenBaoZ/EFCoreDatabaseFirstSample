using System;
using System.Collections.Generic;

namespace EFCoreDatabaseFirstSample.Models
{
    public partial class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
        }

        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public long CategoryId { get; set; }
        public long PublisherId { get; set; }

        public virtual BookCategory Category { get; set; } = null!;
        public virtual Publisher Publisher { get; set; } = null!;

        public virtual ICollection<Author> Authors { get; set; }
    }
}
