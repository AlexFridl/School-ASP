using Application.DataTransferCommand;
using Domain;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Validators
{
    public class TextValidator : AbstractValidator<TextDto>
    {
        public TextValidator(afContext context)
        {
            RuleFor(t => t.NewsId)
                .NotEmpty()
                .WithMessage("Insert NewsId.");
        }
    }
}
