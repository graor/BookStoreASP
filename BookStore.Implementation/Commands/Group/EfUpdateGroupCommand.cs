using AutoMapper;
using BookStore.Application.Commands;
using BookStore.Application.DataTransfer;
using BookStore.DataAccess;
using BookStore.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BookStore.Implementation.Commands
{
    public class EfUpdateGroupCommand : IUpdateGroupCommand
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        private readonly UpdateGroupValidator _validator;

        public EfUpdateGroupCommand(BookStoreContext context, IMapper mapper, UpdateGroupValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "Group Update";

        public void Execute(GroupDto dto)
        {
            _validator.ValidateAndThrow(dto);
            var group = _context.Groups.Find(dto.Id);
            _mapper.Map(dto,group);
            _context.SaveChanges();
        }
    }
}
