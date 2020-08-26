using BookStore.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Queries
{
    public interface IGetAuthorQuery : IQuery<int,AuthorDto>
    {
    }
}
