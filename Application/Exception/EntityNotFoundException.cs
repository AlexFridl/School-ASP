using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exception
{
    public class EntityNotFoundException  : System.Exception
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(int id, Type type)
        : base($"Entity of type {type.Name} with an id {id} was not found.") { }
    }
}
