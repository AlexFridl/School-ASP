using Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransferCommand
{
    public class PictureDto
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }

        public int NewsId { get; set; }
        public IFormFile Image { get; set; }

        //public virtual News News { get; set; }
    }
}
