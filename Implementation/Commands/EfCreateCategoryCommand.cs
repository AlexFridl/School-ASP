using Application.Commands;
using Application.DataTransferCommand;
using AutoMapper;
using Domain;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfCreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly afContext _afContext;
        private readonly CategoryValidator _validators;
        private readonly IMapper _mapper;

        public EfCreateCategoryCommand(afContext afContext, CategoryValidator validator, IMapper mapper)
        {
            _afContext = afContext;
            _validators = validator;
            _mapper = mapper;
        }
        public int Id => 1;

        public string Name => "Create Category";

        public void Execute(CategoryDto request)
        {
            _validators.ValidateAndThrow(request);
            var category = _mapper.Map<Category>(request);
            
            _afContext.Add(category);
            //_afContext.UseCaseLogs.Add(useCase, actor, data);
            _afContext.SaveChanges();
        }
    }
}
