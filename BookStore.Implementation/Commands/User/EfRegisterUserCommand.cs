using AutoMapper;
using BookStore.Application.Commands;
using BookStore.Application.DataTransfer;
using BookStore.Application.Email;
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
    public class EfRegisterUserCommand : IRegisterUserCommand
    {
        private readonly BookStoreContext _context;
        private readonly RegistrationUserValidator _validator;
        private readonly IMapper _mapper;
        private readonly IEmailSender _sender;

        public EfRegisterUserCommand(BookStoreContext context, RegistrationUserValidator validator, IMapper mapper, IEmailSender sender)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
            _sender = sender;
        }

        public int Id => 4;

        public string Name => "Registration";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);
            
            var user = _mapper.Map<User>(request);
            
            _context.Users.Add(user);
            _context.SaveChanges();
            _sender.Send(new SendEmailDto
            {
                Content = "<h1>Successfull registration</h1>",
                SendTo = request.Email,
                Subject = "Registration"
            });
           
        }
    }
}
