using AutoMapper;
using BookStore.Application.DataTransfer;
using BookStore.Application.Exceptions;
using BookStore.Application.Queries;
using BookStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Implementation.Queries
{
    public class EfGetProductQuery : IGetProductQuery
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetProductQuery(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 22;

        public string Name => "Get Product by Id";

        public ProductDto Execute(int search)
        {
            var product = _context.Products.Find(search);
            if (product == null)
            {
                throw new EntityNotFoundException(search, typeof(ProductDto));
            }
            var result = _mapper.Map<ProductDto>(product);
            return result;
        }
    }
}
