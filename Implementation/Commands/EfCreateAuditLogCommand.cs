using Application.Commands;
using Application.DataTransferCommand;
using AutoMapper;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfCreateAuditLogCommand : ICreateAuditLogCommand
    {
        private readonly afContext _afContext;
        private readonly IMapper _mapper;

        public EfCreateAuditLogCommand(afContext afContext, IMapper mapper)
        {
            _afContext = afContext;
            _mapper = mapper;
        }

        public int Id => 29;

        public string Name => "Create AuditLog";

        public void Execute(AuditDto request)
        {
            var auditLog = _mapper.Map<UseCaseLog>(request);

            _afContext.Add(auditLog);
            _afContext.SaveChanges();
        }
    }
}
