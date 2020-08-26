using AutoMapper;
using BookStore.Application.Commands;
using BookStore.Application.DataTransfer;
using BookStore.DataAccess;
using BookStore.Domain;
using BookStore.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Implementation.Commands
{
    public class EfCreateOrderCommand : ICreateOrderCommand
    {
        private readonly BookStoreContext _context;
        private readonly OrderValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateOrderCommand(BookStoreContext context, OrderValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 26;

        public string Name => "Create Order";

        public void Execute(OrderDto request)
        {
            _validator.ValidateAndThrow(request);


            using (var transaction = _context.Database.BeginTransaction())
            {
                var product = _context.Products.Find(request.ProductId);
                var order = new Order
                {
                    Address = request.Address,
                    OrderDate = DateTime.Now,
                    UserId = request.UserId
                };
                product.Quantity -= request.Quantity;
                _context.Orders.Add(order);
                _context.SaveChanges();
                var orderLine = new OrderLine
                {
                    Name = product.Title,
                    Quantity = request.Quantity,
                    Price = product.Price,
                    Address = request.Address,
                    OrderId = order.Id,
                    ProductId = product.Id
                };
                
                _context.OrderLines.Add(orderLine);
                _context.SaveChanges();
                transaction.Commit();
            }
                
        }
    }
}
