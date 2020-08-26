using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application
{
    public interface ICommand<TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }

    public interface IUpdateCommand<Id,Object> : IUseCase
    {
        void Execute(Id id, Object dto);
    }

    public interface IQuery<TSearch, TResult> : IUseCase
    {
        TResult Execute(TSearch search);
    }

    public interface IUseCase
    {
        int Id { get; }
        string Name { get; }
    }
}
