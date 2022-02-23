//using Application.DataTransferQuery;
using Application.Queries;
using Application.Searches;
using AutoMapper;
using Application.Exception;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Application;
using Application.DataTransferCommand;
using Domain;

namespace Implementation.Queries
{
    public class EfGetNewsQuery : IGetNewsQuery
    {
        private readonly afContext _afContext;
        private readonly IMapper _mapper;

        public EfGetNewsQuery(afContext afContext, IMapper mapper)
        {
            _afContext = afContext;
            _mapper = mapper;
        }

        public int Id => 8;

        public string Name => "Search News";

        PagedResponse<NewsDto> ICommands.IQuery<NewsSearch, PagedResponse<NewsDto>>.Execute(NewsSearch search)
        {
            var query = _afContext.Newses.Include(x => x.Category).AsQueryable();

            if (search == null)
            {
                throw new EntityNotFoundException();
            }
            query = query.Where(x => x.CategoryId == search.CategoryId);

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<Application.DataTransferCommand.NewsDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),

                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new Application.DataTransferCommand.NewsDto
                {
                    Id = x.Id,
                    TitleNews = x.TitleNews,
                    Subtitle = x.Subtitle,
                    CreatedAt = x.CreatedAt,
                    CategoryId = x.CategoryId
                }).ToList()
            

            };
            //query = query.Skip(skipCount).Take(search.PerPage);
            //response.Items = _mapper.Map<List<NewsDto>>(query.ToList());

            return response;
        }
    }
}
