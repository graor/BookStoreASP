using BookStore.Application.Commands;
using BookStore.Application.Exceptions;
using BookStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using BookStore.Domain;

namespace BookStore.Implementation.Commands
{
    public class EfDeleteAuthorCommand : IDeleteAuthorCommand
    {
        private readonly BookStoreContext _context;

        public EfDeleteAuthorCommand(BookStoreContext context)
        {
            _context = context;
        }

        public int Id => 8;

        public string Name => "Delete Author";

        public void Execute(int request)
        {
            var author = _context.Authors.Find(request);
            if (author == null)
            {
                throw new EntityNotFoundException(request, typeof(Author));
            }
            author.IsDeleted = true;
            author.DeletedAt = DateTime.Now;
            author.IsActive = false;
            _context.SaveChanges();
        }
    }
}
