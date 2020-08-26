using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain
{
    public class Author : Entity
    {
        public string  AuthorName { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
