using Application;
using Application.Commands;
using Application.Exception;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfDeleteTextCommand : IDeleteTextCommand
    {
        private readonly afContext _afContext;
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;

        public EfDeleteTextCommand(afContext afContext, UseCaseExecutor executor, IApplicationActor actor)
        {
            _afContext = afContext;
            _executor = executor;
            _actor = actor;
        }
        public int Id => 15;

        public string Name => "Delete Text";

        public void Execute(int request)
        {
            var text = _afContext.Texts.Find(request);

            if (text == null)
            {
                throw new EntityNotFoundException();
            }
            text.IsActive = false;
            text.DeletedAt = DateTime.Now;
            text.IsDeleted = true;
            _afContext.SaveChanges();

        }
    }
}
