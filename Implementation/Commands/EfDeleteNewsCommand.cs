using Application.Commands;
using Application.Exception;
using AutoMapper;
using EfDataAccess;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfDeleteNewsCommand : IDeleteNewsCommand
    {
        private readonly afContext _afContext;
        private readonly IMapper _mapper;
       // private readonly NewsValidator _validators;


        public EfDeleteNewsCommand(afContext afContext, IMapper mapper/*, NewsValidator validator*/)
        {
            _afContext = afContext;
            _mapper = mapper;
           // _validators = validator;
        }

        public int Id => 7;

        public string Name => "Delete News";


        public void Execute(int request)
        {
            var news = _afContext.Newses.Find(request);

            if (news == null)
            {
                throw new EntityNotFoundException();
            }

            news.IsActive = false;
            news.IsDeleted = true;
            news.DeletedAt = DateTime.Now;
            _afContext.SaveChanges();

        }
    }
}
