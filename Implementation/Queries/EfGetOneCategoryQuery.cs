using Application.DataTransferCommand;
using Application.Exception;
using Application.Queries;
using AutoMapper;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetOneCategoryQuery : IGetOneCategoryQuery
    {
        private readonly afContext _afContext;
        private readonly IMapper _mapper;
        public EfGetOneCategoryQuery(afContext afContext, IMapper mapper)
        {
            _afContext = afContext;
            _mapper = mapper;
        }

        public int Id => 22;

        public string Name => "Get one category";

        public CategoryDto Execute(int request)
        {
            
            var category = _afContext.Categories.Find(request);
           
            if (category == null)
            {
                throw new EntityNotFoundException();
            }

            var category_Dto = _mapper.Map<CategoryDto>(category);
            return category_Dto;

        }
    }
}
