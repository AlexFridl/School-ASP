using Application.Commands;
using Application.DataTransferCommand;
using AutoMapper;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Implementation.Commands
{
    public class EfCreatePictureCommand : ICreatePictureCommand
    {
        private readonly afContext _afContext;
        private readonly IMapper _mapper;
        

        public EfCreatePictureCommand(afContext afContext, IMapper mapper)
        {
            _afContext = afContext;

            _mapper = mapper;
        }

        public int Id => 17;

        public string Name => "Create Picture";

        public void Execute(PictureDto request)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(request.Image.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                request.Image.CopyTo(fileStream);
            }
            var picture = _mapper.Map<Picture>(request);

            _afContext.Add(picture);
            _afContext.SaveChanges();
        }

    }
}
