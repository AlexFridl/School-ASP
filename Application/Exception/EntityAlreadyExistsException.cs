using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exception
{
    public class EntityAlreadyExistsException : System.Exception
    {
        public EntityAlreadyExistsException() { }
        public EntityAlreadyExistsException(int id, Type type)
            : base($"Entity of type {type.Name} with an id {id} already exist") { }

    }
}
