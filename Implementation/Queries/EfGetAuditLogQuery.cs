using Application.DataTransferCommand;
using Application.Queries;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetAuditLogQuery : IGetAuditLogQuery
    {
        private readonly afContext _afContext;
        public EfGetAuditLogQuery(afContext afContext)
        {
            _afContext = afContext;
        }
        public int Id => 27;

        public string Name => "Category Search";


        public PagedResponse<AuditDto> Execute(AuditLogSearch search)
        {
            var query = _afContext.UseCaseLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.UseCaseName) || !string.IsNullOrWhiteSpace(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }

            if(!string.IsNullOrEmpty(search.Actor) || !string.IsNullOrWhiteSpace(search.Actor))
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.Actor.ToLower()));
            }

            /* var response = query.Select(x => new CategoryDto
             {
                 Id = x.Id,
                 Name = x.Name
             }).ToList();
             return response;*/
            var skipCount = search.PerPage * (search.Page - 1);

            var reponse = new PagedResponse<AuditDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new AuditDto
                {
                    Id = x.Id,
                    UseCaseName = x.UseCaseName,
                    Data = x.Data,
                    Actor = x.Actor
                }).ToList()
            };

            return reponse;

        }
    }
}
