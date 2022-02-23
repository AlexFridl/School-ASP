using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands;
using Application.DataTransferCommand;
using Application.Queries;
using Application.Searches;
using EfDataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly afContext _afContext;
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;

        public NewsController(afContext afContext, UseCaseExecutor executor, IApplicationActor actor)
        {
            _afContext = afContext;
            _executor = executor;
            _actor = actor;
        }
        // GET: api/News
        [HttpGet]
        public IActionResult Get([FromQuery] NewsSearch search, [FromServices] IGetNewsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/News/5
        [HttpGet("{id}", Name = "GetNews")]
        public IActionResult Get(int id, [FromServices] IGetOneNewsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/NewsController
        [HttpPost]
        public void Post([FromBody] NewsDto dto, [FromServices] ICreateNewsCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT: api/News/5
          [HttpPut("{id}")]
           public IActionResult Put(int id, [FromBody] NewsDto dto, [FromServices] IUpdateNewsCommand command)
           {
               dto.Id = id;
               _executor.ExecuteCommand(command, dto);
            return NoContent();
           }
           
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteNewsCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }

    }
}
