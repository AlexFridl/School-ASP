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
    public class EfUpdateTextCommand : IUpdateTextCommand
    {
        private readonly afContext _afContext;
        private readonly TextValidator _validators;
        private readonly IMapper _mapper;

        public EfUpdateTextCommand(afContext afContext, TextValidator validator,IMapper mapper)
        {
            _afContext = afContext;
            _validators = validator;
            _mapper = mapper;
        }

        public int Id => 14;

        public string Name => "Update Text";

        public void Execute(TextDto request)
        {
            _validators.ValidateAndThrow(request);

            var text = _afContext.Texts.Find(request.Id);

            if (text == null)
            {
                throw new EntityNotFoundException();
            }

            text.TextNews = request.TextNews;
            text.ModifiedAt = DateTime.Now;
            text.NewsId = request.NewsId;

            _afContext.SaveChanges();

        }
    }
}
