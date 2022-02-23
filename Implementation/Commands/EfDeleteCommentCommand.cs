using Application.Commands;
using Application.Exception;
using AutoMapper;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Implementation.Commands
{
    public class EfDeleteCommentCommand : IDeleteCommentCommand
    {
        private readonly afContext _afContext;
        private readonly IMapper _mapper;
        //private readonly CommentValidator _validators;


        public EfDeleteCommentCommand(afContext afContext, IMapper mapper/*, CommentValidator validator*/)
        {
            _afContext = afContext;
            _mapper = mapper;
            //_validators = validator;
        }

        public int Id => 11;

        public string Name => "Delete Comment";

        public void Execute(int request)
        {
            var comment = _afContext.Comments.Find(request);

            if (comment == null)
            {
                throw new EntityNotFoundException();
            }

            comment.IsActive = false;
            comment.IsDeleted = true;
            comment.DeletedAt = DateTime.Now;
            _afContext.SaveChanges();

        }

    }
}
