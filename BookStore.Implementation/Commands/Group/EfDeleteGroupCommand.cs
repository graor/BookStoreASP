using BookStore.Application.Commands;
using BookStore.Application.Exceptions;
using BookStore.DataAccess;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BookStore.Implementation.Commands
{
    public class EfDeleteGroupCommand : IDeleteGroupCommand
    {
        private readonly BookStoreContext _context;

        public EfDeleteGroupCommand(BookStoreContext context)
        {
            _context = context;
        }

        public int Id => 2;

        public string Name => "Delete Group";

        public void Execute(int request)
        {
            var group = _context.Groups.Find(request);
            if (group == null)
            {
                throw new EntityNotFoundException(request, typeof(Group));
            }
            group.IsDeleted = true;
            group.DeletedAt = DateTime.Now;
            group.IsActive = false;
            _context.SaveChanges();
        }
    }
}
