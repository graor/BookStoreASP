using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.DataTransfer
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
