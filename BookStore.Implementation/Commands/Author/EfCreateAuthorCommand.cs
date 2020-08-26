using AutoMapper;
using BookStore.Application.Commands;
using BookStore.Application.DataTransfer;
using BookStore.DataAccess;
using BookStore.Domain;
using BookStore.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Implementation.Commands
{
    public class EfCreateAuthorCommand : ICreateAuthorCommand
    {
        private readonly BookStoreContext _context;
        private readonly CreateAuthorValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateAuthorCommand(BookStoreContext context, CreateAuthorValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 7;

        public string Name => "Create New Author";

        public void Execute(AuthorDto request)
        {
            _validator.ValidateAndThrow(request);

             var author = _mapper.Map<Author>(request);

           
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }
}
