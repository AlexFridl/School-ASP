using Application.Commands;
using Application.DataTransferCommand;
using Application.Email;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfRegisterUseCommand : IRegisterUserCommand
    {

        private readonly afContext _afContext;
        private readonly RegisterUserValidator _validator;
        private readonly IEmailSender _sender;

      public EfRegisterUseCommand(afContext afContext, RegisterUserValidator validator,IEmailSender sender)
      {
            _afContext = afContext;
            _validator = validator;
            _sender = sender;
      }

        public int Id => 4;

        public string Name => "User Registration";

        public void Execute(RegisterUserDto request)
        {
            _validator.ValidateAndThrow(request);

            _afContext.Users.Add(new Domain.User
            {
                FristName = request.FristName,
                LastName = request.LastName,
                Username = request.Username,
                Password = request.Password,
                Email = request.Email
            });
            _afContext.SaveChanges();
            _sender.Sender(new SendEmailDto
            {
                Content = "<h1>Successfull registration!</h1>",
                SendTo = request.Email,
                Subject = "Registration"
            }) ;
        }
    }
}
