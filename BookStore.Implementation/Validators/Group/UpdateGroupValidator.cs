using BookStore.Application.DataTransfer;
using BookStore.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BookStore.Implementation.Validators
{
    public class UpdateGroupValidator : AbstractValidator<GroupDto>
    {
        public UpdateGroupValidator(BookStoreContext context)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .Must(x => context.Groups.Any(g => g.Id == x))
                .WithMessage($"Group with this id doesn't exist ");
            RuleFor(x => x.GroupName)
                .Must(x => !context.Groups.Any(g => g.GroupName == x))
                .WithMessage("Group must have unique name");
        }
    }
}
