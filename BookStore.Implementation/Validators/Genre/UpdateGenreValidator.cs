using BookStore.Application.DataTransfer;
using BookStore.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BookStore.Implementation.Validators
{
    public class UpdateGenreValidator : AbstractValidator<GenreDto>
    {
        public UpdateGenreValidator(BookStoreContext context)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Choose Id of Genre that you want to change")
                .Must(x => context.Genres.Any(g => g.Id == x))
                .WithMessage(x => $"Genre with Id: {x.Id} doesn't exist in the database");
            RuleFor(x => x.GenreName)
                .NotEmpty()
                .WithMessage("Genre Name is required");
        }
    }
}
