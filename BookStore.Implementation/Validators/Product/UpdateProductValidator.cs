using BookStore.Application.DataTransfer;
using BookStore.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BookStore.Implementation.Validators
{
    public class UpdateProductValidator : AbstractValidator<ProductDto>
    {
        public UpdateProductValidator(BookStoreContext context)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Choose Product")
                .Must(x => context.Products.Any(p => p.Id == x))
                .WithMessage(x => $"Product with Id:{x.Id} doesn't exist in the database");
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required");
            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0");
        }
    }
}
