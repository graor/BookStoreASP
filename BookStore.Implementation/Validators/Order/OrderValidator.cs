using BookStore.Application.DataTransfer;
using BookStore.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BookStore.Implementation.Validators
{
    public class OrderValidator :AbstractValidator<OrderDto>
    {
        public OrderValidator(BookStoreContext context)
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("Choose some product")
                .Must(x => context.Products.Any(p => p.Id == x))
                .WithMessage(x => $"Product with Id:{x.ProductId} doesn't exist in the database");
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("You need to be Login if you want to order Product")
                .Must(x => context.Users.Any(u => u.Id == x))
                .WithMessage(x => $"User with Id: {x.UserId} doesn't exists");
            RuleFor(x => x).Must(x=>context.Products.Any(p => p.Id == x.ProductId && p.Quantity >= x.Quantity))
                .WithMessage(x=>$"Only {x.Quantity} products are available righ now");
        }
    }
}
