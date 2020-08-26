using BookStore.Application.DataTransfer;
using BookStore.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BookStore.Implementation.Validators
{
    public class CreateProductValidator : AbstractValidator<ProductDto>
    {
        public CreateProductValidator(BookStoreContext context)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.AuthorId).NotEmpty().WithMessage("Author is required");
            RuleFor(x => x.GenreId).NotEmpty().WithMessage("Genre is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Quantity is required");
        }
    }
}
