using BookStore.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Searches
{
    public class UseCaseLogSearch : PagedSearch
    {
        public DateTime fromDate { get; set; }
        public DateTime? toDate { get; set; } = null;
        public string useCaseName { get; set; }
        public string actor { get; set; }
    }
}
