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
    public class EfGetOnePictureQuery : IGetOnePictureQuery
    {
        private readonly afContext _afContext;
        private readonly IMapper _mapper;
        public EfGetOnePictureQuery(afContext afContext, IMapper mapper)
        {
            _afContext = afContext;
            _mapper = mapper;
        }


        public int Id => 25;

        public string Name => "Get one Picture";

        public PictureDto Execute(int search)
        {
            var picture = _afContext.Pictures.Find(search);
            if (picture == null)
            {
                throw new EntityNotFoundException();
            }
            var picture_Dto = _mapper.Map<PictureDto>(picture);

            return picture_Dto;
        }
    }
}
