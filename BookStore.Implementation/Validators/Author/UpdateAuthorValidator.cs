using BookStore.Application.DataTransfer;
using BookStore.DataAccess;
using BookStore.Domain;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Implementation.Validators
{
    public class UpdateAuthorValidator : AbstractValidator<AuthorDto>
    {
        public UpdateAuthorValidator(BookStoreContext context)
        {
            RuleFor(x => x.AuthorName)
                 .NotEmpty()
                 .WithMessage("Author Name is required");
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Choose Author that you want to change")
                .Must(x => context.Authors.Any(a => a.Id == x))
                .WithMessage(x => $"Author with this Id: {x.Id} doesn't exist in database");
        }
    }
}
