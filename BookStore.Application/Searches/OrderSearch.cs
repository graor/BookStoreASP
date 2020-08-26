using BookStore.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Searches
{
    public class OrderSearch : PagedSearch
    {
        public int? UserId { get; set; }
        public string Address { get; set; }

    }
}
