using Application.Commands;
using Application.DataTransferCommand;
using Application.Exception;
using AutoMapper;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EfUpdateNewsCommand : IUpdateNewsCommand
    {
        private readonly afContext _afContext;
        //private readonly IMapper _mapper;
        private readonly NewsValidator _validators;


        public EfUpdateNewsCommand(afContext afContext, /*IMapper mapper, */NewsValidator validator)
        {
            _afContext = afContext;
           // _mapper = mapper;
            _validators = validator;
        }

        public int Id => 6;

        public string Name => "Update News";

        public void Execute(NewsDto request)
        {
            var news = _afContext.Newses.Find(request.Id);

            if (news == null)
            {
                throw new EntityNotFoundException();
            }
            _validators.ValidateAndThrow(request);
            
            news.TitleNews = request.TitleNews;
            news.Subtitle = request.Subtitle;
            news.ModifiedAt = DateTime.Now;
                
            _afContext.SaveChanges();
        }
    }
}

