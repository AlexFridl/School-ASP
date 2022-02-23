using System;
using System.Collections.Generic;
using System.Text;
using static Application.ICommands;

namespace Application.Exception
{
    public class UnauthorizedUseCaseException : System.Exception
    {
        public UnauthorizedUseCaseException(IUseCase useCase, IApplicationActor actor)
            : base($"Actor with an id of {actor.Id} - {actor.Identity} tried to execute {useCase.Name}.") { }
    }
}
