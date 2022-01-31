using JwtApi.Interfaces;
using JwtApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JwtApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public UserController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        // GET: api/<UserCred>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "*** Para Saber Que El Token Si Funca ***" };
        }

        // GET api/<UserCred>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserCred>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] Users users)
        {

            var token = jwtAuthenticationManager.Authenticate(users.Username, users.Password);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
       
    }
}
