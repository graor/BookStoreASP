using BookStore.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Searches
{
    public class ProductSearch : PagedSearch
    {
        public string Title { get; set; }
        public int? authorId { get; set; }
        public int? genreId { get; set; }
        public decimal? minPrice { get; set; }
        public decimal? maxPrice { get; set; }
        public int? Quantity { get; set; }
    }
}
