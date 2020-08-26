using BookStore.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Searches
{
    public class GroupSearch : PagedSearch
    {
        public string  GroupName { get; set; }
    }
}
