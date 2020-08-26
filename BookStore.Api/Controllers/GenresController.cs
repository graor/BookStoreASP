using System;
using System.Collections.Generic;
using System.Linq;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public GenresController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/Genres
        [HttpGet]
        public IActionResult Get([FromQuery] GenreSearch search,
            [FromServices]IGetGenresQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/Genres/5
        [HttpGet("{id}", Name = "GetGenre")]
        public IActionResult Get(int id,
            [FromServices] IGetGenreQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Genres
        [HttpPost]
        public void Post([FromBody] GenreDto dto,
            [FromServices] ICreateGenreCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT: api/Genres/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] GenreDto dto,
            [FromServices]IUpdateGenreCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id,
            [FromServices] IDeleteGenreCommand command)
        {
            _executor.ExecuteCommand(command, id);
        }
    }
}
