using Application.DataTransferCommand;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core
{
    public class TextProfile : Profile
    {
        public TextProfile()
        {
            CreateMap<Text, TextDto>();
            CreateMap<TextDto, Text>();
        }
    }
}
