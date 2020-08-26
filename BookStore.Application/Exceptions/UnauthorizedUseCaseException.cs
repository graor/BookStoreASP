using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Exceptions
{
    public class UnauthorizedUseCaseException : Exception
    {
        public UnauthorizedUseCaseException(IUseCase useCase,IApplicationActor actor)
            : base($"Actor with Id: {actor.Id} - {actor.Identity} tryed to execute {useCase.Name}")
        {

        }
    }
}
