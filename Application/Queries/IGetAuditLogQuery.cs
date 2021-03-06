using Application.DataTransferCommand;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;
using static Application.ICommands;

namespace Application.Queries
{
    public interface IGetAuditLogQuery : IQuery<AuditLogSearch, PagedResponse<AuditDto>>
    {
    }
}
