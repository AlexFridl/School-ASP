using Application.DataTransferCommand;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class NewsValidator : AbstractValidator<NewsDto>
    {
        public NewsValidator(afContext context)
        {
            RuleFor(n => n.TitleNews)
               .NotEmpty()
               .Must(titleName => !context.Newses.Any(n => n.TitleNews == titleName))
               .WithMessage("Title news is already in table!");
            RuleFor(n => n.CategoryId)
                .NotEmpty()
                .WithMessage("News must belong to category.");
        }
    }
}
