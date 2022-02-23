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
    public class EfGetOneAuditLogQuery : IGetOneAuditLogQuery
    {

        private readonly afContext _afContext;
        private readonly IMapper _mapper;
        public EfGetOneAuditLogQuery(afContext afContext, IMapper mapper)
        {
            _afContext = afContext;
            _mapper = mapper;
        }


        public int Id => 28;

        public string Name => "Get one Use Case Log";

        public UseCaseLogDto Execute(int search)
        {
            var auditLog = _afContext.UseCaseLogs.Find(search);

            if (auditLog == null)
            {
                throw new EntityNotFoundException();
            }
            var auditLog_Dto = _mapper.Map<UseCaseLogDto>(auditLog);
            //var category_Dto = _mapper.Map<CategoryDto>(category);
            return auditLog_Dto;


        }
    }
}
