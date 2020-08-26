using AutoMapper;
using BookStore.Application.Commands;
using BookStore.Application.DataTransfer;
using BookStore.DataAccess;
using BookStore.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Implementation.Commands
{
    public class EfUpdateGenreCommand : IUpdateGenreCommand
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        private readonly UpdateGenreValidator _validator;

        public EfUpdateGenreCommand(BookStoreContext context, IMapper mapper, UpdateGenreValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 12;

        public string Name => "Update Genre";

        public void Execute(GenreDto request)
        {
            _validator.ValidateAndThrow(request);
            var genre = _context.Genres.Find(request.Id);
            _mapper.Map(request, genre);
            _context.SaveChanges();
        }
    }
}
