using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id, Type type)
            : base($"Entity of type: {type} and Id: {id} wasn't found")
        {

        }
    }
}
