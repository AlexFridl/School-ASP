using Application.DataTransferCommand;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;
using static Application.ICommands;

namespace Application.Queries
{
    public interface IGetPictureQuery : IQuery<PictureSearch, PagedResponse<PictureDto>>
    {
    }
}
