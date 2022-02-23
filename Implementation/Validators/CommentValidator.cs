using Application.DataTransferCommand;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Validators
{
    public class CommentValidator : AbstractValidator<CommentDto>
    {
        public CommentValidator(afContext afContext)
        {
            RuleFor(c => c.TextComment)
                .NotEmpty()
                .WithMessage("Insert comment.");
            RuleFor(n => n.NewsId)
                .NotEmpty()
                .WithMessage("Insert NewsId.");
            RuleFor(n => n.UserId)
                .NotEmpty()
                .WithMessage("Insert UserId.");
                
        }
    }
}
