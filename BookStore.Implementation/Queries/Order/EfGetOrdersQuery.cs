using AutoMapper;
using BookStore.Application.DataTransfer;
using BookStore.Application.Queries;
using BookStore.Application.Searches;
using BookStore.DataAccess;
using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Implementation.Queries
{
    public class EfGetOrdersQuery : IGetOrdersQuery
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetOrdersQuery(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 29;

        public string Name => "Get Orders";

        public PagedResponse<OrderDto> Execute(OrderSearch search)
        {
            var query = _context.Orders.Include(x => x.OrderLines).AsQueryable();
            if (search.UserId != null)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }
            if(!string.IsNullOrEmpty(search.Address) || !string.IsNullOrWhiteSpace(search.Address))
            {
                query = query.Where(x => x.Address.ToLower().Contains(search.Address.ToLower()));
            }
            var skipCount = search.PerPage * (search.Page - 1);
            var response = new PagedResponse<OrderDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => _mapper.Map<OrderDto>(x))
            };
            return response;
        }
    }
}
