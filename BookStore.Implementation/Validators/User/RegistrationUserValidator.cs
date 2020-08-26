using BookStore.Application.DataTransfer;
using BookStore.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Implementation.Validators
{
    public class RegistrationUserValidator : AbstractValidator<UserDto>
    {
        public RegistrationUserValidator(BookStoreContext context)
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required")
                .Must(x => !context.Users.Any(u => u.Username == x))
                .WithMessage("This username is already taken");
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First Name is required");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last Name is required");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required");
        }
    }
}
