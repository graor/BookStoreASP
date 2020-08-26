using BookStore.Application.DataTransfer;
using BookStore.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace BookStore.Implementation.Validators
{
    public class CreateGenreValidator : AbstractValidator<GenreDto>
    {
        private readonly BookStoreContext _context;
        public CreateGenreValidator()
        {
            RuleFor(x => x.GenreName)
                .NotEmpty()
                .WithMessage("Genre Name is required")
                .Must(x => !_context.Genres.Any(g => g.GenreName == x))
                .WithMessage("This genre already exist in the database");
        }

        public CreateGenreValidator(BookStoreContext context)
        {
            _context = context;
        }
    }
}
