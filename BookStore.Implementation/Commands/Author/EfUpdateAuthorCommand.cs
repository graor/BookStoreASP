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
    public class EfUpdateAuthorCommand : IUpdateAuthorCommand
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        private readonly UpdateAuthorValidator _validator;

        public EfUpdateAuthorCommand(BookStoreContext context, IMapper mapper, UpdateAuthorValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 9;

        public string Name => "Update Author";

        public void Execute(AuthorDto request)
        {
            _validator.ValidateAndThrow(request);
            var author = _context.Authors.Find(request.Id);
            _mapper.Map(request, author);
            _context.SaveChanges();
        }
    }
}
