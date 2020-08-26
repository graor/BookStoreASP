using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BookStore.Application;
using BookStore.Application.Commands;
using BookStore.Application.DataTransfer;
using BookStore.Application.Queries;
using BookStore.Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;

        public UsersController(UseCaseExecutor executor, IApplicationActor actor)
        {
            _executor = executor;
            _actor = actor;
        }
        [Authorize]
        // GET: api/Users
        [HttpGet]
        public IActionResult Get([FromQuery]UserSearch search,
            [FromServices]IGetUsersQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }
        [Authorize]
        // GET: api/Users/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(int id,
            [FromServices] IGetUserQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Users
        [HttpPost]
        public void Post([FromBody] UserDto dto,
            [FromServices] IRegisterUserCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }
        [Authorize]
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserDto dto,
            [FromServices]IUpdateUserCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
        }
        [Authorize]
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id,
            [FromServices]IDeleteUserCommand command)
        {
            _executor.ExecuteCommand(command, id);
        }
    }
}
