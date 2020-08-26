using BookStore.Application.DataTransfer;
using BookStore.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BookStore.Implementation.Validators
{
    public class CreateAuthorValidator : AbstractValidator<AuthorDto>
    {
        public CreateAuthorValidator(BookStoreContext context)
        {
            RuleFor(x => x.AuthorName)
                .NotEmpty()
                .WithMessage("Author Name is required")
                .Must(x => !context.Authors.Any(a => a.AuthorName == x))
                .WithMessage("Author with this name already exists in the database");
        }
    }
}
