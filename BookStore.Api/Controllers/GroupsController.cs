using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;
        private readonly IMapper _mapper;

        public GroupsController(IApplicationActor actor, UseCaseExecutor executor, IMapper mapper)
        {
            _actor = actor;
            _executor = executor;
            _mapper = mapper;
        }

        // GET: api/Groups
        [HttpGet]
        public IActionResult Get(
            [FromQuery] GroupSearch search,
            [FromServices] IGetGroupsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query,search));
        }

        // GET: api/Groups/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id,
            [FromServices]IGetGroupQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Groups
        [HttpPost]
        public void Post([FromBody] GroupDto dto,
            [FromServices] ICreateGroupCommand command)
        {
            _executor.ExecuteCommand(command,dto);
        }

        // PUT: api/Groups/5
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] GroupDto dto,
            [FromServices] IUpdateGroupCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteGroupCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
