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
    public class CreateGroupValidator : AbstractValidator<GroupDto>
    {
        public CreateGroupValidator(BookStoreContext context)
        {
            RuleFor(x => x.GroupName)
                .NotEmpty()
                .WithMessage("Group Name is required")
                .Must(n => !context.Groups.Any(g => g.GroupName == n))
                .WithMessage("Group Name must be unique");
        }
    }
}
