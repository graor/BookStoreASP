using BookStore.Application.Commands;
using BookStore.Application.Exceptions;
using BookStore.DataAccess;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Implementation.Commands
{
    public class EfDeleteOrderCommand : IDeleteOrderCommand
    {
        private readonly BookStoreContext _context;

        public EfDeleteOrderCommand(BookStoreContext context)
        {
            _context = context;
        }

        public int Id => 27;

        public string Name => "Delete Order";

        public void Execute(int request)
        {
            var order = _context.Orders.Find(request);
            if (order == null)
            {
                throw new EntityNotFoundException(request, typeof(Order));
            }
            order.IsActive = false;
            order.IsDeleted = true;
            order.DeletedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
