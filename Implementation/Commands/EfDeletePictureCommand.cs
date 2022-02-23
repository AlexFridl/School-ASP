using Application.Commands;
using Application.Exception;
using AutoMapper;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfDeletePictureCommand : IDeletePictureCommand
    {
        private readonly afContext _afContext;
        private readonly IMapper _mapper;
        //private readonly PictureValidator _validators;


        public EfDeletePictureCommand(afContext afContext, IMapper mapper/*, PictureValidator validator*/)
        {
            _afContext = afContext;
            _mapper = mapper;
         //   _validators = validator;
        }


        public int Id => 19;

        public string Name => "Delete Picture";

        public void Execute(int request)
        {
            var picture = _afContext.Pictures.Find(request);

            if (picture == null)
            {
                throw new EntityNotFoundException();
            }
            picture.IsActive = false;
            picture.IsDeleted = true;
            picture.DeletedAt = DateTime.Now;
            _afContext.SaveChanges();
        }
    }
}
