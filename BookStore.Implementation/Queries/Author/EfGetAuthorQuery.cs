using AutoMapper;
using BookStore.Application;
using BookStore.Application.DataTransfer;
using BookStore.Application.Exceptions;
using BookStore.Application.Queries;
using BookStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Implementation.Queries
{
    public class EfGetAuthorQuery : IGetAuthorQuery
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetAuthorQuery(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 19;

        public string Name => "Get Author by Id";

        public AuthorDto Execute(int search)
        {
            var author = _context.Authors.Find(search);
            if (author == null)
            {
                throw new EntityNotFoundException(search, typeof(AuthorDto));
            }
            var response = _mapper.Map<AuthorDto>(author);
            return response;
        }
    }
}
