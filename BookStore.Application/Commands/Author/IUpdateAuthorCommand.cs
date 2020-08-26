using BookStore.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Commands 
{
    public interface IUpdateAuthorCommand : ICommand<AuthorDto>
    {
    }
}
