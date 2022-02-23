using Application.Commands;
using Application.DataTransferCommand;
using AutoMapper;
using Domain;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfCreateCommentCommand : ICreateCommentCommand
    {
        private readonly afContext _afContext;
        private readonly CommentValidator _validators;
        private readonly IMapper _mapper;

        public EfCreateCommentCommand(afContext afContext, CommentValidator validator, IMapper mapper)
        {
            _afContext = afContext;
            _validators = validator;
            _mapper = mapper;
        }
        public int Id => 9;

        public string Name => "Create Comment";

        public void Execute(CommentDto request)
        {
            _validators.ValidateAndThrow(request);
            var comment = _mapper.Map<Comment>(request);
            comment.CreatedAt = DateTime.Now;

            _afContext.Add(comment);
            _afContext.SaveChanges();
        }
    }
}
