using Application.DataTransferCommand;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Api.Core
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
         
        /*  CreateMap<News, NewsDto>()
                .ForMember{ 
                     dto => dto.Categories,
                     opt => opt.MapFrom(x => x.Categories)
                                .Select(y => y.Name)
                }); 
             }
        */

            CreateMap<News, NewsDto>();
            CreateMap<NewsDto, News>();
        }
    }
}