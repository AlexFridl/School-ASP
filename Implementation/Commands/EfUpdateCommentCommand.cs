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
    public class EfUpdateCommentCommand : IUpdateCommentCommand
    {
        private readonly afContext _afContext;
        private readonly IMapper _mapper;
        private readonly CommentValidator _validators;


        public EfUpdateCommentCommand(afContext afContext, IMapper mapper, CommentValidator validator)
        {
            _afContext = afContext;
            _mapper = mapper;
            _validators = validator;
        }

        public int Id => 10;

        public string Name => "Update Comment";

        public void Execute(CommentDto request)
        {
            _validators.ValidateAndThrow(request);
            var comment = _afContext.Comments.Find(request.Id);

            if (comment == null)
            {
                throw new EntityNotFoundException();
            }

            comment.TextComment = request.TextComment;
            comment.ModifiedAt = DateTime.Now;
            comment.UserId = request.UserId;
            _afContext.SaveChanges();

        }

    }
}
