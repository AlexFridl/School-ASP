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
    public class CommentController : ControllerBase
    {
        private readonly afContext _afContext;
        private readonly UseCaseExecutor _executor;

        public CommentController(afContext afContext, UseCaseExecutor executor)
        {
            _executor = executor;
            _afContext = afContext;
        }

        // GET: api/Comment
        [HttpGet]
        public IActionResult Get([FromQuery] CommentSearch search, [FromServices] IGetCommentQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/Comment/5
        [HttpGet("{id}", Name = "GetComment")]
        public IActionResult Get(int id, [FromServices] IGetOneCommentQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Comment
        [HttpPost]
        public void Post([FromBody] CommentDto dto, [FromServices] ICreateCommentCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT: api/Comment/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CommentDto dto, [FromServices] IUpdateCommentCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCommentCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }

    }

}
