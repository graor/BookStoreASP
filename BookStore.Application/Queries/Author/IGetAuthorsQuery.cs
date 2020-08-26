using BookStore.Application.DataTransfer;
using BookStore.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Queries
{
    public interface IGetAuthorsQuery : IQuery<AuthorSearch,PagedResponse<AuthorDto>>
    {
    }
}
