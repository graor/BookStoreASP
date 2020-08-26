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
    public class EfGetUserQuery : IGetUserQuery
    {

        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetUserQuery(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 23;

        public string Name => "Get User by Id";

        public UserDto Execute(int search)
        {
            var user = _context.Users.Find(search);
            if (user == null)
            {
                throw new EntityNotFoundException(search, typeof(UserDto));
            }
            var result = _mapper.Map<UserDto>(user);
            return result;
        }
    }
}
