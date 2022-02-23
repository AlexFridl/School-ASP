using System;
using System.Collections.Generic;
using System.Text;
using static Application.ICommands;

namespace Application
{
    public interface IUseCaseLogger
    {
        void Log(IUseCase useCase, IApplicationActor actor, object data);
    }
}
