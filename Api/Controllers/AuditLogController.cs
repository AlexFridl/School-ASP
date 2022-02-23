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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogController : ControllerBase
    {
        private readonly afContext _afContext;
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;

        public AuditLogController(afContext afContext, UseCaseExecutor executor, IApplicationActor actor)
        {
            _afContext = afContext;
            _executor = executor;
            _actor = actor;

        }


        // GET: api/AuditLog
        [HttpGet]
        public IActionResult Get([FromQuery] AuditLogSearch search, [FromServices] IGetAuditLogQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/AuditLog/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id, [FromServices] IGetOneAuditLogQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

       
    }
}
