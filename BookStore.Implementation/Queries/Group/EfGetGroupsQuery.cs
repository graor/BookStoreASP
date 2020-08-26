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
    public class EfGetGroupsQuery : IGetGroupsQuery
    {
        private readonly BookStoreContext _context;

        public EfGetGroupsQuery(BookStoreContext context)
        {
            _context = context;
        }

        public int Id => 16;

        public string Name => "Group search";

        public PagedResponse<GroupDto> Execute(GroupSearch search)
        {
            var query = _context.Groups.AsQueryable();
            if(!string.IsNullOrEmpty(search.GroupName) || !string.IsNullOrWhiteSpace(search.GroupName))
            {
                query = query.Where(x => x.GroupName.ToLower().Contains(search.GroupName.ToLower()));
            }
            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<GroupDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new GroupDto
                {
                    Id = x.Id,
                    GroupName = x.GroupName
                }).ToList()
            };
            return response;
            
        }
    }
}
