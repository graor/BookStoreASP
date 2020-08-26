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
    public class EfGetGenresQuery : IGetGenresQuery
    {
        private readonly BookStoreContext _context;

        public EfGetGenresQuery(BookStoreContext context)
        {
            _context = context;
        }

        public int Id => 18;

        public string Name => "Get Genres";

        public PagedResponse<GenreDto> Execute(GenreSearch search)
        {
            var query = _context.Genres.AsQueryable();
            if(!string.IsNullOrEmpty(search.Genre) || !string.IsNullOrWhiteSpace(search.Genre))
            {
                query = query.Where(x => x.GenreName.ToLower().Contains(search.Genre.ToLower()));
            }
            var skipCount = search.PerPage * (search.Page - 1);
            var response = new PagedResponse<GenreDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new GenreDto
                {
                    Id = x.Id,
                    GenreName = x.GenreName
                }).ToList()
            };
            return response;
        }
    }
}
