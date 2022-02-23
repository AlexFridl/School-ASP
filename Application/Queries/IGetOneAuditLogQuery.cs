using Application.DataTransferCommand;
using System;
using System.Collections.Generic;
using System.Text;
using static Application.ICommands;

namespace Application.Queries
{
    public interface IGetOneAuditLogQuery : IQuery<int, UseCaseLogDto>
    {
    }
}
