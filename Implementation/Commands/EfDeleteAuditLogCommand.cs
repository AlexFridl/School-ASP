using Application.Commands;
using Application.DataTransferCommand;
using Application.Exception;
using AutoMapper;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfDeleteAuditLogCommand : IDeleteAuditLogCommand
    {
        private readonly afContext _afContext;
        private readonly IMapper _mapper;


        public EfDeleteAuditLogCommand(afContext afContext, IMapper mapper)
        {
            _afContext = afContext;
            _mapper = mapper;
        }


        public int Id => 31;

        public string Name => "AuditLog Delete";

        public void Execute(int request)
        {
            var auditLog = _afContext.UseCaseLogs.Find(request);
            if (auditLog == null)
            {
                throw new EntityNotFoundException();
            }


            _afContext.Remove(auditLog);
            _afContext.SaveChanges();

        }
    }
}
