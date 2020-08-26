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
    public class UpdateUserValidator : AbstractValidator<UserDto>
    {
        public UpdateUserValidator(BookStoreContext context)
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required")
                .Must((dto, name) => !context.Users.Any(p => p.Username == name && p.Id != dto.Id))
                .WithMessage(p => $"Product with the Username: {p.Username} already exists");
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First Name is required");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last Name is required");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .Must((dto, email) => !context.Users.Any(u => u.Email == email && u.Id != dto.Id))
                .WithMessage("Another user has this email");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
