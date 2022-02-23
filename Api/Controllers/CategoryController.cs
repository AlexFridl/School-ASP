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
    public class CategoryController : ControllerBase
    {
        private readonly afContext _afContext;
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;

        public CategoryController(afContext afContext, UseCaseExecutor executor, IApplicationActor actor)
        {
            _afContext = afContext;
            _executor = executor;
            _actor = actor;

        }

        // GET: api/Category
        [HttpGet]

        public IActionResult Get([FromQuery] CategorySearch search, [FromServices] IGetCategoryQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name= "categoryId")]
        public IActionResult Get( int id, [FromServices] IGetOneCategoryQuery query)
        {
           return Ok( _executor.ExecuteQuery(query, id));
        }

        // POST: api/Category
        [HttpPost]
        public void Post([FromBody] CategoryDto dto, [FromServices] ICreateCategoryCommand command)
        {
                _executor.ExecuteCommand(command, dto);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryDto dto, [FromServices] IUpdateCategoryCommand command)
        {
                dto.Id = id;

                _executor.ExecuteCommand(command, dto);
                return NoContent();
        }

        //DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCategoryCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }

    }
}
