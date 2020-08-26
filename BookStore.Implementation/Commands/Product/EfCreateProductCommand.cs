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
    public class EfCreateProductCommand : ICreateProductCommand
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        private readonly CreateProductValidator _validator;

        public EfCreateProductCommand(BookStoreContext context, IMapper mapper, CreateProductValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 13;

        public string Name => "Create New Product";

        public void Execute(ProductDto request)
        {
            _validator.ValidateAndThrow(request);
            var product = _mapper.Map<Product>(request);
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
