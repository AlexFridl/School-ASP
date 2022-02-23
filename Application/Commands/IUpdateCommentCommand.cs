using Application.DataTransferCommand;
using System;
using System.Collections.Generic;
using System.Text;
using static Application.ICommands;

namespace Application.Commands
{
    public interface IUpdateCommentCommand : ICommand<CommentDto>
    {
    }
}
