using Application.Commands;
using Application.DataTransferCommand;
using Application.Exception;
using AutoMapper;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EfUpdateAuditLogCommand : IUpdateAuditLogCommand
    {
        private readonly afContext _afContext;
        private readonly IMapper _mapper;


        public EfUpdateAuditLogCommand(afContext afContext, IMapper mapper)
        {
            _afContext = afContext;
            _mapper = mapper;
        }

        public int Id => 30;

        public string Name => "AuditLog Update";

        public void Execute(AuditDto request)
        {
            var auditLog = _afContext.UseCaseLogs.Find(request.Id);

            if (auditLog == null)
            {
                throw new EntityNotFoundException();
            }

            if (auditLog.Actor != request.Actor)
            {
                if (_afContext.UseCaseLogs.Any(c => c.Actor == request.Actor))
                {
                    throw new EntityAlreadyExistsException();
                }

                auditLog.UseCaseName = request.UseCaseName;
                auditLog.Date = DateTime.Now;
                auditLog.Actor = request.Actor;

                _afContext.SaveChanges();


            }
        }
    }
}
