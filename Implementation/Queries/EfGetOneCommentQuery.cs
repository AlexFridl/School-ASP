using Application.DataTransferCommand;
using Application.Exception;
using Application.Queries;
using AutoMapper;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetOneCommentQuery : IGetOneCommentQuery
    {
        private readonly afContext _afContext;
        private readonly IMapper _mapper;

        public EfGetOneCommentQuery(afContext afContext, IMapper mapper)
        {
            _afContext = afContext;
            _mapper = mapper;
        }


        public int Id => 23;

        public string Name => "Get one comment";

        public CommentDto Execute(int search)
        {

            var comment = _afContext.Comments.Find(search);
            if (comment == null)
            {
                throw new EntityNotFoundException();
            }

            var comment_Dto = _mapper.Map<CommentDto>(comment);

            return comment_Dto;


        }
    }

}
