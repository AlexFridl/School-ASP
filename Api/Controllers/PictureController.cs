using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands;
using Application.DataTransferCommand;
using Application.Queries;
using Application.Searches;
using AutoMapper;
using Domain;
using EfDataAccess;
using Implementation.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly afContext _afContext;
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;
       // private readonly IMapper _mapper;

        public PictureController(afContext afContext, UseCaseExecutor executor, IApplicationActor actor/*, IMapper mapper*/)
        {
            _afContext = afContext;
            _executor = executor;
            _actor = actor;
          //  _mapper = mapper;
        }
        // GET: api/Picture
        [HttpGet]
        public IActionResult Get([FromQuery] PictureSearch search, [FromServices] IGetPictureQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/Picture/5
        [HttpGet("{id}", Name = "GetPicture")]
        public IActionResult Get(int id, [FromServices] IGetOnePictureQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Picture
        [HttpPost]
        public void Post([FromForm] PictureDto dto)
        {
           
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(dto.Image.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                dto.Image.CopyTo(fileStream);
            }
            var picture = new Picture
            {
                Src = newFileName,
                Alt = newFileName,
                NewsId = dto.NewsId

            };
            _afContext.Pictures.Add(picture);
            _afContext.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePictureCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
    
    public class UploadDto
    {
        public IFormFile Image { get; set; }
    }

}
