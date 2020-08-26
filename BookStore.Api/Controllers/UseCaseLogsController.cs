using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Application;
using BookStore.Application.Queries;
using BookStore.Application.Searches;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseCaseLogs : ControllerBase
    {

        private readonly UseCaseExecutor _executor;

        public UseCaseLogs(UseCaseExecutor executor)
        {
            _executor = executor;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] UseCaseLogSearch search,
            [FromServices] IGetUseCaseQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

    }
}
