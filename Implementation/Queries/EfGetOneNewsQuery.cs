using Application.DataTransferCommand;
using Application.Exception;
using Application.Queries;
using AutoMapper;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetOneNewsQuery : IGetOneNewsQuery
    {
        private readonly afContext _afContext;
        private readonly IMapper _mapper;

        public EfGetOneNewsQuery(afContext afContext, IMapper mapper)
        {
            _afContext = afContext;
            _mapper = mapper;
        }


        public int Id => 24;

        public string Name => "Get one News";

        public NewsDto Execute(int search)
        {
            var news = _afContext.Newses.Find(search);
            //var query = _afContext.Newses.Include(x => x.Category).AsQueryable();
            

            if (news == null)
            {
                throw new EntityNotFoundException();
            }

            var news_Dto = _mapper.Map<NewsDto>(news);

        /*    var response = query.Select(x => new Application.DataTransferCommand.NewsDto
            {
                Id = x.Id,
                TitleNews = x.TitleNews,
                Subtitle = x.Subtitle,
                CreatedAt = x.CreatedAt,
                CategoryName = query.Select(x => x.Name)
            }).ToList();
         */
            return news_Dto;

           



        }

    }
}
