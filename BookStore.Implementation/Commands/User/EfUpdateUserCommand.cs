using AutoMapper;
using BookStore.Application.Commands;
using BookStore.Application.DataTransfer;
using BookStore.DataAccess;
using BookStore.Domain;
using BookStore.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BookStore.Implementation.Commands
{
    public class EfUpdateUserCommand : IUpdateUserCommand
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        private readonly UpdateUserValidator _validator;

        public EfUpdateUserCommand(BookStoreContext context, IMapper mapper, UpdateUserValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 6;

        public string Name => "Update User";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);
            var user = _context.Users.Find(request.Id);
            _mapper.Map(request,user);
            _context.SaveChanges();
        }
    }
}
