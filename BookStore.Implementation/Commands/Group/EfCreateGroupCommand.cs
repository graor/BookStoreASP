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
    public class EfCreateGroupCommand : ICreateGroupCommand
    {
        private readonly BookStoreContext _context;
        private readonly CreateGroupValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateGroupCommand(BookStoreContext context, CreateGroupValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 1;
        public string Name => "Create New Group using EF";

        public void Execute(GroupDto request)
        {
            _validator.ValidateAndThrow(request);

            var group = new Group
            {
                GroupName = request.GroupName
            };
            _context.Groups.Add(group);
            _context.SaveChanges();
        }
    }
}
