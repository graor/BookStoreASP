using BookStore.Application.Commands;
using BookStore.Application.DataTransfer;
using BookStore.DataAccess;
using BookStore.Domain;
using BookStore.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BookStore.Implementation.Commands
{
    public class EfUpdateOrderCommand : IUpdateOrderCommand
    {
        private readonly BookStoreContext _context;
        private readonly UpdateOrderValidator _validator;

        public EfUpdateOrderCommand(BookStoreContext context, UpdateOrderValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 28;
        public string Name => "Update Order";

        public void Execute(OrderDto request)
        {
            _validator.ValidateAndThrow(request);
            var order = _context.Orders.Find(request.Id);
            if (order.OrderStatus == OrderStatus.Shipped)
            {
                return ;
            }
            
            var product = _context.Products.Find(request.ProductId);
            order.Address = request.Address;


            var orderline = _context.OrderLines.Where(x => x.OrderId == request.Id).First();

            product.Quantity += orderline.Quantity - request.Quantity;

            orderline.Name = product.Title;
            orderline.Quantity = request.Quantity;
            orderline.Price = product.Price;
            orderline.Address = request.Address;
            orderline.ProductId = product.Id;

                
            _context.SaveChanges();
            
        }
    }
}
