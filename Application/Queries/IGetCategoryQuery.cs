using Application.DataTransferCommand;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;
using static Application.ICommands;

namespace Application.Queries
{
    public interface IGetCategoryQuery : IQuery<CategorySearch, PagedResponse<CategoryDto>>
    {
    }
}
