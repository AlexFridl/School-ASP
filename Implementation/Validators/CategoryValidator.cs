using Application.DataTransferCommand;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator(afContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Must(name => !context.Categories.Any(c => c.Name == name))
                .WithMessage("Name is required");
            RuleFor(n => n.Name)
               .NotEmpty()
               .Must(name => !context.Categories.Any(n => n.Name == name))
               .WithMessage("Category name already exist!");
        }
    }
}
