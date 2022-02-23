using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransferCommand
{
    public class NewsDto
    {
        public int Id { get; set; }
        public string TitleNews { get; set; }
        public string Subtitle { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }
    }
}
