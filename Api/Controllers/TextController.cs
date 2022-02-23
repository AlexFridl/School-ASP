using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands;
//using Application.DataTransferQuery;
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
    public class TextController : ControllerBase
    {
        private readonly afContext _afContext;
        private readonly UseCaseExecutor _executor;

        public TextController(afContext afContext, UseCaseExecutor executor)
        {
            _afContext = afContext;
            _executor = executor;
        }

        // GET: api/TextController
        [HttpGet]
        public IActionResult Get([FromQuery] TextSearch search, [FromServices] IGetTextQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/TextController/5
        [HttpGet("{id}", Name = "GetText")]
        public IActionResult Get(int id, [FromServices] IGetOneTextQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/TextController
        [HttpPost]
        public void Post([FromBody] Application.DataTransferCommand.TextDto dto, [FromServices] ICreateTextCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT: api/TextController/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Application.DataTransferCommand.TextDto dto, [FromServices] IUpdateTextCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteTextCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }

    }

}
