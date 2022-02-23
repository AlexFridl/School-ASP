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
    public class EfGetOneTextQuery : IGetOneTextQuery
    {
        private readonly afContext _afContext;
        private readonly IMapper _mapper;

        public EfGetOneTextQuery(afContext afContext, IMapper mapper)
        {
            _afContext = afContext;
            _mapper = mapper;
        }
        public int Id => 26;

        public string Name => "Get one Text";

        public TextDto Execute(int search)
        {
            var text = _afContext.Texts.Find(search);
            var text_Dto = _mapper.Map<TextDto>(text);

            if (text == null)
            {
                throw new EntityNotFoundException();
            }

            return text_Dto;
        }
    }
}
