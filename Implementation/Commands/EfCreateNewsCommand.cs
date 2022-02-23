using Application.Commands;
using Application.DataTransferCommand;
using AutoMapper;
using Domain;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfCreateNewsCommand : ICreateNewsCommand
    {
        private readonly afContext _afContext;
        private readonly NewsValidator _validators;
        private readonly IMapper _mapper;

        public EfCreateNewsCommand(afContext afContext, NewsValidator validator, IMapper mapper)
        {
            _afContext = afContext;
            _validators = validator;
            _mapper = mapper;
        }

        public int Id => 5;

        public string Name => "News Category";

        public void Execute(NewsDto request)
        {
            _validators.ValidateAndThrow(request);
            var news = _mapper.Map<News>(request);
            news.CreatedAt = DateTime.Now;

            _afContext.Add(news);
            _afContext.SaveChanges();
        }
    }
}
