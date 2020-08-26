using BookStore.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Searches
{
    public class UserSearch :PagedSearch
    {
        public string fName{ get; set; }
        public string lName { get; set; }
        public string Username { get; set; }
    }
}
