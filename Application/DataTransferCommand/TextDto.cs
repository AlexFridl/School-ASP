using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransferCommand
{
    public class TextDto
    {
        public int Id { get; set; }
        public string TextNews { get; set; }

        public int NewsId{ get; set; }
    }
}
