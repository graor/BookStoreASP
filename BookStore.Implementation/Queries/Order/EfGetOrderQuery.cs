using AutoMapper;
using BookStore.Application.DataTransfer;
using BookStore.Application.Exceptions;
using BookStore.Application.Queries;
using BookStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BookStore.Implementation.Queries
{
    public class EfGetOrderQuery : IGetOrderQuery
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetOrderQuery(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 30;

        public string Name => "Get Order by Id";

        public OrderDto Execute(int search)
        {
            var order = _context.Orders.Find(search);
            if (order == null)
            {
                throw new EntityNotFoundException(search, typeof(OrderDto));
            }
            var result = _mapper.Map<OrderDto>(order);
            return result;
        }
    }
}
