using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransferCommand
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string TextComment { get; set; }
        public int NewsId { get; set; }
        public int UserId { get; set; }
    }
}
