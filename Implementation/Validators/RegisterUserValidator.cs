using Application.DataTransferCommand;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator(afContext context)
        {
            RuleFor(x => x.FristName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty()
                .MinimumLength(6);
            RuleFor(x => x.Username).NotEmpty()
                .MinimumLength(4)
                .Must(x => !context.Users.Any(user => user.Username == x))
                .WithMessage("Username is already taken!");
            RuleFor(x => x.Email).NotEmpty()
                .EmailAddress()
                .WithMessage("You must enter email.");

        }
    }
}
