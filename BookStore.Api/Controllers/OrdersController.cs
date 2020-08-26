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
    public class OrdersController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public OrdersController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/Orders
        [HttpGet]
        public IActionResult Get([FromQuery] OrderSearch search,
            [FromServices] IGetOrdersQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/Orders/5
        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult Get(int id,
            [FromServices]IGetOrderQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Orders
        [HttpPost]
        public void Post([FromBody] OrderDto dto,
            [FromServices]ICreateOrderCommand command)
        {
            _executor.ExecuteCommand(command, dto);   
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderDto dto,
            [FromServices]IUpdateOrderCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id,
            [FromServices]IDeleteOrderCommand command)
        {
            _executor.ExecuteCommand(command, id);
        }
    }
}
