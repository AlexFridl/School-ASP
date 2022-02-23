using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands;
using Application.DataTransferCommand;
using EfDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly afContext _afContext;

        public RegisterController(UseCaseExecutor executor, afContext afContext)
        {
            _executor = executor;
            _afContext = afContext;
        }


        // POST: api/Register
        [HttpPost]
        public void Post([FromBody] RegisterUserDto dto,[FromServices] IRegisterUserCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }

    }
}
