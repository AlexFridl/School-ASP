using Application;
using Application.DataTransferCommand;
using Application.Queries;
using Application.Searches;
using Domain;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class EFGetCategoryQuery : IGetCategoryQuery
    {
        private readonly afContext _afContext;
        public EFGetCategoryQuery(afContext afContext)
        {
            _afContext = afContext;
        }
        public int Id => 3;

        public string Name => "Category Search";

       
        PagedResponse<CategoryDto> ICommands.IQuery<CategorySearch, PagedResponse<CategoryDto>>.Execute(CategorySearch search)
        {
            var query = _afContext.Categories.Include(x => x.Newses).AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            /* var response = query.Select(x => new CategoryDto
             {
                 Id = x.Id,
                 Name = x.Name
             }).ToList();
             return response;*/
            var skipCount = search.PerPage * (search.Page - 1);

            var reponse = new PagedResponse<CategoryDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    
                }) .ToList()
            };

            return reponse;
        }
    }
}
