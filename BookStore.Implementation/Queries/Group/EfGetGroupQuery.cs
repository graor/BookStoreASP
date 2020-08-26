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
    public class EfGetGroupQuery : IGetGroupQuery
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetGroupQuery(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 21;

        public string Name => "Get Group by Id";

        public GroupDto Execute(int search)
        {
            var group = _context.Groups.Find(search);
            if (group == null)
            {
                throw new EntityNotFoundException(search, typeof(GroupDto));
            }
            var result = _mapper.Map<GroupDto>(group);
            return result;
        }
    }
}
