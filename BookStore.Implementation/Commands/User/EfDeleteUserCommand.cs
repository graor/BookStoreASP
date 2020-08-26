using BookStore.Application.Commands;
using BookStore.Application.Exceptions;
using BookStore.DataAccess;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BookStore.Implementation.Commands
{
    public class EfDeleteUserCommand : IDeleteUserCommand
    {
        private readonly BookStoreContext _context;

        public EfDeleteUserCommand(BookStoreContext context)
        {
            _context = context;
        }

        public int Id => 5;

        public string Name => "Delete User";

        public void Execute(int request)
        {
            var user = _context.Users.Find(request);
            if (user == null)
            {
                throw new EntityNotFoundException(request, typeof(User));
            }
            user.IsActive = false;
            user.IsDeleted = true;
            user.DeletedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
