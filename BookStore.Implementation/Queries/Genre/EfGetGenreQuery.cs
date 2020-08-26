using AutoMapper;
using BookStore.Application.DataTransfer;
using BookStore.Application.Exceptions;
using BookStore.Application.Queries;
using BookStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BookStore.Implementation.Queries
{
    public class EfGetGenreQuery : IGetGenreQuery
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetGenreQuery(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 20;

        public string Name => "Get Author by Id";

        public GenreDto Execute(int search)
        {
            var author = _context.Genres.Find(search);
            if (author == null)
            {
                throw new EntityNotFoundException(search, typeof(GenreDto));
            }
            var result = _mapper.Map<GenreDto>(author);
            return result;
        }
    }
}
