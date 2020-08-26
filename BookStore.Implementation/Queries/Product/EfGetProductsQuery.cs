using AutoMapper;
using BookStore.Application.DataTransfer;
using BookStore.Application.Queries;
using BookStore.Application.Searches;
using BookStore.DataAccess;
using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Implementation.Queries
{
    public class EfGetProductsQuery : IGetProductsQuery
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetProductsQuery(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 25;

        public string Name => "Get Products";

        public PagedResponse<ProductDto> Execute(ProductSearch search)
        {
            var query = _context.Products
                .Include(x => x.Genre)
                .Include(x => x.Author)
                .AsQueryable();
            
            if (!string.IsNullOrEmpty(search.Title) || !string.IsNullOrWhiteSpace(search.Title))
            {
                query = query.Where(x => x.Title.ToLower().Contains(search.Title.ToLower()));
            }
            if (search.authorId != null)
            {
                query = query.Where(x => x.AuthorId == search.authorId);
            }
            if (search.genreId != null)
            {
                query = query.Where(x => x.GenreId == search.genreId);
            }
            if (search.minPrice != null)
            {
                query = query.Where(x => x.Price >= search.minPrice);
            }
            if (search.maxPrice != null)
            {
                query = query.Where(x => x.Price <= search.maxPrice);
            }
            if (search.Quantity != null)
            {
                query = query.Where(x => x.Quantity >= search.Quantity);
            }
            var skipCount = search.PerPage * (search.Page - 1);
            var response = new PagedResponse<ProductDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => _mapper.Map<ProductDto>(x))
            };
            return response;
        }
    }
}
