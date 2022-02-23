using Application;
using EfDataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Logging
{
    public class DatabaseUseCaseLogger : IUseCaseLogger 
    {
        private readonly afContext _afContext;

        public DatabaseUseCaseLogger(afContext context)
        {
            _afContext = context;
        }

        public void Log(ICommands.IUseCase useCase, IApplicationActor actor, object data)
        {
            _afContext.UseCaseLogs.Add(new Domain.UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(data),
                Date = DateTime.UtcNow,
                UseCaseName = useCase.Name
            });
            _afContext.SaveChanges();

        }


    }
}
