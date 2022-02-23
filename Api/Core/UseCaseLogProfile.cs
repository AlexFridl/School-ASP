using AutoMapper;
using Application.DataTransferCommand;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core
{
    public class UseCaseLogProfile : Profile
    {
        public UseCaseLogProfile()
        {
            CreateMap<UseCaseLog, UseCaseLogDto>();
            CreateMap<UseCaseLogDto,UseCaseLog >();
        }
    }
}
