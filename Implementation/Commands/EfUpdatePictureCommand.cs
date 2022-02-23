using Application.Commands;
using Application.DataTransferCommand;
using Application.Exception;
using AutoMapper;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EfUpdatePictureCommand : IUpdatePictureCommand
    {
        private readonly afContext _afContext;
        private readonly IMapper _mapper;
        //private readonly PictureValidator _validators;


        public EfUpdatePictureCommand(afContext afContext, IMapper mapper/*, PictureValidator validator*/)
        {
            _afContext = afContext;
            _mapper = mapper;
           // _validators = validator;
        }

        public int Id => 18;

        public string Name => "Update Picture";

        public void Execute(PictureDto request)
        {
            var picture = _afContext.Pictures.Find(request.Id);

            if (picture == null)
            {
                throw new EntityNotFoundException();
            }

            if (picture.Alt != request.Alt)
            {
                if (_afContext.Pictures.Any(c => c.Src == request.Src))
                {
                    throw new EntityAlreadyExistsException();
                }

                picture.Alt = request.Alt;
                picture.Src = request.Src;

                _afContext.SaveChanges();
            }
        }
    }
}
