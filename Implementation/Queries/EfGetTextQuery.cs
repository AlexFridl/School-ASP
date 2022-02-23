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
    public class EfGetTextQuery : IGetTextQuery
    {
        private readonly afContext _afContext;
        
        public EfGetTextQuery(afContext afContext)
        {
            _afContext = afContext;
        }

        public int Id => 16;

        public string Name => "Search Text";

        public PagedResponse<TextDto> Execute(TextSearch search)
        {
            var query = _afContext.Texts.Include(x => x.News).AsQueryable();
            query = query.Where(x => x.NewsId == search.NewsId);

            if (search == null)
            {
                throw new EntityNotFoundException();
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<Application.DataTransferCommand.TextDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),

                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new Application.DataTransferCommand.TextDto
                {
                    Id = x.Id,
                    TextNews = x.TextNews,
                    NewsId = x.NewsId
                }).ToList()
            };

            return response;
        }
    }
}
