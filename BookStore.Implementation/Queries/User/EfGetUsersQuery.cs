using AutoMapper;
using BookStore.Application.DataTransfer;
using BookStore.Application.Queries;
using BookStore.Application.Searches;
using BookStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Implementation.Queries
{
    public class EfGetUsersQuery : IGetUsersQuery
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetUsersQuery(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 24;

        public string Name => "Get Users";

        public PagedResponse<UserDto> Execute(UserSearch search)
        {
            var query = _context.Users.AsQueryable();
            if(!string.IsNullOrEmpty(search.fName) || !string.IsNullOrWhiteSpace(search.fName))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.fName.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.lName) || !string.IsNullOrWhiteSpace(search.lName))
            {
                query = query.Where(x => x.LastName.ToLower().Contains(search.lName.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.Username) || !string.IsNullOrWhiteSpace(search.Username))
            {
                query = query.Where(x => x.Username.ToLower().Contains(search.Username.ToLower()));
            }
            var skipCount = search.PerPage * (search.Page - 1);
            var response = new PagedResponse<UserDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => _mapper.Map<UserDto>(x))
            };
            return response;
        }
    }
}
