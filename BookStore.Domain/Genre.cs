using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain
{
    public class Genre : Entity
    {
        public string GenreName { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
