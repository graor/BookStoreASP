using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Application;
using BookStore.Application.Commands;
using BookStore.Application.DataTransfer;
using BookStore.Application.Queries;
using BookStore.Application.Searches;
using BookStore.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;

        public AuthorsController(UseCaseExecutor executor, IApplicationActor actor)
        {
            _executor = executor;
            _actor = actor;
        }

        // GET: api/Authors
        [HttpGet]
        public IActionResult Get([FromQuery]AuthorSearch search,
            [FromServices]IGetAuthorsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query,search));
        }

        // GET: api/Authors/5
        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult Get(int id,
            [FromServices] IGetAuthorQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Authors
        [HttpPost]
        public void Post([FromBody] AuthorDto dto,
            [FromServices] ICreateAuthorCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AuthorDto dto,
            [FromServices] IUpdateAuthorCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id,
            [FromServices] IDeleteAuthorCommand command)
        {
            _executor.ExecuteCommand(command, id);
        }
    }
}
