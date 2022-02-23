using Application.Commands;
using Application.DataTransferCommand;
using AutoMapper;
using Domain;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Implementation.Commands
{
    public class EfCreateTextCommand : ICreateTextCommand
    {
        private readonly afContext _afContext;
        private readonly IMapper _mapper;
        private readonly TextValidator _validator;

        public EfCreateTextCommand(afContext afContext, TextValidator validator, IMapper mapper)
        {
            _afContext = afContext;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 13;

        public string Name => "Create Text";



        public void Execute(TextDto request)
        {
            _validator.ValidateAndThrow(request);

            var text = _mapper.Map<Text>(request);
            text.CreatedAt = DateTime.Now;

            _afContext.Add(text);
            _afContext.SaveChanges();
        }
    }
}
