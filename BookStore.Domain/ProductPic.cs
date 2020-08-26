using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain
{
    public class ProductPic : Entity
    {
        public string src { get; set; }
        public string alt { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
