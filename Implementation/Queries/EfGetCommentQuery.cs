using Application.DataTransferCommand;
using Application.Exception;
using Application.Queries;
using Application.Searches;
using AutoMapper;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetCommentQuery : IGetCommentQuery
    {
        private readonly afContext _afContext;
        private readonly IMapper _mapper;

        public EfGetCommentQuery(afContext afContext, IMapper mapper)
        {
            _afContext = afContext;
            _mapper = mapper;
        }


        public int Id => 12;

        public string Name => "Search Comment";

        public PagedResponse<CommentDto> Execute(CommentSearch search)
        {
            var query = _afContext.Comments.Include(x => x.Users).Include(x => x.News).AsQueryable();

            query = query.Where(x => x.UserId == search.UserId);
            //  query = query.Where(x => x.UserId == search.UserId);

            if (search == null)
            {
                throw new EntityNotFoundException();
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<CommentDto>
            {
                ItemsPerPage = search.PerPage,
                CurrentPage = search.Page,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new CommentDto
                {
                    Id = x.Id,
                    TextComment = x.TextComment,
                    NewsId = x.NewsId,
                    UserId = x.UserId
                }).ToList()
            };
            return response;

        }

    }
}
