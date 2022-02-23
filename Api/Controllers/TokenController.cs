using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Core;
using Application;
using EfDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

            private readonly JwtManager _jwtManager;
           public TokenController(JwtManager jwtManager)
           {
              _jwtManager = jwtManager;
           }
        
        // POST: api/Token
        [HttpPost]
           public IActionResult Post([FromBody] LoginRequest request)
           {
               var token = _jwtManager.MakeToken(request.UserName, request.Password);

               if (token == null)
               {
                   return Unauthorized();
               }
               return Ok(new { token });

           }
       

        public class LoginRequest
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

    }
    }

