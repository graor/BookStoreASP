using AutoMapper;
using BookStore.Application.Commands;
using BookStore.Application.DataTransfer;
using BookStore.Application.Exceptions;
using BookStore.DataAccess;
using BookStore.Domain;
using BookStore.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Implementation.Commands
{
    public class EfUpdateProductCommand : IUpdateProductCommand
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        private readonly UpdateProductValidator _validator;

        public EfUpdateProductCommand(BookStoreContext context, IMapper mapper, UpdateProductValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 15;

        public string Name => "Update Product";

        public void Execute(ProductDto request)
        {
            _validator.ValidateAndThrow(request);
            var product = _context.Products.Find(request.Id);
            if (product == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Product));
            }
            _mapper.Map(request, product);
            _context.SaveChanges();
        }
    }
}
