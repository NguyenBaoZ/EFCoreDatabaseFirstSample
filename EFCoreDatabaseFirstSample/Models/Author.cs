﻿using System;
using System.Collections.Generic;

namespace EFCoreDatabaseFirstSample.Models
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual AuthorContact AuthorContact { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
