using AutoMapper;
using BookStore.Application.Commands;
using BookStore.Application.DataTransfer;
using BookStore.DataAccess;
using BookStore.Domain;
using BookStore.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BookStore.Implementation.Commands
{
    public class EfCreateGenreCommand : ICreateGenreCommand
    {
        private readonly CreateGenreValidator _validator;
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public EfCreateGenreCommand(CreateGenreValidator validator, BookStoreContext context, IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }

        public int Id => 10;

        public string Name => "Create New Genre";

        public void Execute(GenreDto request)
        {
            _validator.ValidateAndThrow(request);
            var genre = _mapper.Map<Genre>(request);
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }
}
