using BookStore.Application.Commands;
using BookStore.Application.DataTransfer;
using BookStore.Application.Exceptions;
using BookStore.DataAccess;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Implementation.Commands
{
    public class EfDeleteProductCommand : IDeleteProductCommand
    {
        private readonly BookStoreContext _context;

        public EfDeleteProductCommand(BookStoreContext context)
        {
            _context = context;
        }

        public int Id => 14;

        public string Name => "Delete Product";

        public void Execute(int request)
        {
            var product = _context.Products.Find(request);
            if (product == null)
            {
                throw new EntityNotFoundException(request,typeof(Product));
            }
            product.IsDeleted = true;
            product.IsActive = false;
            product.DeletedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
