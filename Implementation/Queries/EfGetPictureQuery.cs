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
    public class EfGetPictureQuery : IGetPictureQuery
    {
        private readonly afContext _afContext;
        private readonly IMapper _mapper;


        public EfGetPictureQuery(afContext afContext, IMapper mapper)
        {
            _afContext = afContext;
            _mapper = mapper;
        }

        public int Id => 20;

        public string Name => "Search Picture";

        public PagedResponse<PictureDto> Execute(PictureSearch search)
        {
            var query = _afContext.Pictures.Include(x => x.News).AsQueryable();

            if (search == null)
            {
                throw new EntityNotFoundException();
            }
            query = query.Where(x => x.NewsId == search.NewsId);

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<PictureDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new PictureDto
                {
                    Id = x.Id,
                    Src = x.Src,
                    Alt = x.Alt,
                    NewsId = x.NewsId
                }).ToList()
            };

            return response;
        }
    }
}
