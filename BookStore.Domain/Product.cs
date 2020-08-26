using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain
{
    public class Product : Entity
    {
        public string  Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();
        public virtual ICollection<ProductPic> ProductPics { get; set; } = new HashSet<ProductPic>();
    }
}
