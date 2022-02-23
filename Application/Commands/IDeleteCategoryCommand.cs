using System;
using System.Collections.Generic;
using System.Text;
using static Application.ICommands;

namespace Application.Commands
{
    public interface IDeleteCategoryCommand : ICommand<int>
    {
    }
}
