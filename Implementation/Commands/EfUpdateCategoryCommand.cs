using Application.Commands;
using Application.DataTransferCommand;
using Application.Exception;
using AutoMapper;
using Domain;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EfUpdateCategoryCommand : IUpdateCategoryCommand
    {
        private readonly afContext _afContext;
       // private readonly IMapper _mapper;
        private readonly CategoryValidator _validators;


        public EfUpdateCategoryCommand(afContext afContext, /*IMapper mapper,*/ CategoryValidator validator)
        {
            _afContext = afContext;
           // _mapper = mapper;
            _validators = validator;
        }
        public int Id => 2;

        public string Name => "Category Update";


        public void Execute(CategoryDto request)
        {
            var category = _afContext.Categories.Find(request.Id);

            if (category == null)
            {
                throw new EntityNotFoundException();
            }
            _validators.ValidateAndThrow(request);

            category.ModifiedAt = DateTime.Now;
         //   _mapper.Map<Category>(request);

             category.Name = request.Name;

            _afContext.SaveChanges();
        }

    }
}
