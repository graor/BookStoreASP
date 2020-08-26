using BookStore.Application.DataTransfer;
using BookStore.Application.Queries;
using BookStore.Application.Searches;
using BookStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace BookStore.Implementation.Queries
{
    public class EfGetAuthorsQuery : IGetAuthorsQuery
    {
        private readonly BookStoreContext _context;

        public EfGetAuthorsQuery(BookStoreContext context)
        {
            _context = context;
        }

        public int Id => 17;

        public string Name => "Authors Search";

        public PagedResponse<AuthorDto> Execute(AuthorSearch search)
        {
            var query = _context.Authors.AsQueryable();
            if(!string.IsNullOrEmpty(search.Author) || !string.IsNullOrWhiteSpace(search.Author))
            {
                query = query.Where(x => x.AuthorName.ToLower().Contains(search.Author.ToLower()));
            }
            var skipCount = search.PerPage * (search.Page - 1);
            var response = new PagedResponse<AuthorDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new AuthorDto
                {
                    Id = x.Id,
                    AuthorName = x.AuthorName
                }).ToList()
            };
            return response;
        }
    }
}
