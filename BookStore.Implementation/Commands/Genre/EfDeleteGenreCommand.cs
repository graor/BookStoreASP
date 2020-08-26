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
    public class EfDeleteGenreCommand : IDeleteGenreCommand
    {
        private readonly BookStoreContext _context;

        public EfDeleteGenreCommand(BookStoreContext context)
        {
            _context = context;
        }

        public int Id => 11;

        public string Name => "Delete Genre";

        public void Execute(int request)
        {
            var genre = _context.Genres.Find(request);
            if (genre == null)
            {
                throw new EntityNotFoundException(request, typeof(Genre));
            }
            genre.IsActive = false;
            genre.IsDeleted = true;
            genre.DeletedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
