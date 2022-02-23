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
    public class EfDeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly afContext _afContext;
        private readonly IMapper _mapper;
       // private readonly CategoryValidator _validators;


        public EfDeleteCategoryCommand(afContext afContext, IMapper mapper/*, CategoryValidator validator*/)
        {
            _afContext = afContext;
            _mapper = mapper;
       //     _validators = validator;
        }

        public int Id => 4;
        public string Name => "Delete Category";

        public void Execute(int request)
        {
            var category = _afContext.Categories.Find(request);
            if (category == null)
            {
                throw new EntityNotFoundException();
            }

            category.IsDeleted = true;
            category.IsActive = false;
            category.DeletedAt = DateTime.Now;
            _afContext.SaveChanges();
        }
    }
}
