using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BookStore.Application.DataTransfer;
using BookStore.Application.Queries;
using BookStore.Application.Searches;
using BookStore.DataAccess;

namespace BookStore.Implementation.Queries
{
    public class EfGetUseCaseLogsQuery : IGetUseCaseQuery
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        public EfGetUseCaseLogsQuery(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 31;

        public string Name => "Logs";

        public PagedResponse<UseCaseLogDto> Execute(UseCaseLogSearch search)
        {
            var query = _context.UseCaseLogs.AsQueryable();
            if (!string.IsNullOrEmpty(search.useCaseName) || !string.IsNullOrWhiteSpace(search.useCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.useCaseName.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.actor) || !string.IsNullOrWhiteSpace(search.actor))
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.actor.ToLower()));
            }
            if (search.fromDate != null)
            {
                query = query.Where(x => x.Date.CompareTo(search.fromDate)>=0);
            }
            //if (search.toDate!=null && search.toDate>search.fromDate)
            //{
            //    query = query.Where(x => x.Date.CompareTo(search.toDate)<=0);
            //}
            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<UseCaseLogDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => _mapper.Map<UseCaseLogDto>(x)) };
            return response;
        }
    }
}
