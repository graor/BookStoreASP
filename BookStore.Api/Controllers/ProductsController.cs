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
    public class ProductsController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public ProductsController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/Products
        [HttpGet]
        public IActionResult Get([FromQuery] ProductSearch search,
            [FromServices]IGetProductsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query,search));
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get(int id,
            [FromServices]IGetProductQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Products
        [HttpPost]
        public void Post([FromBody] ProductDto dto,
            [FromServices]ICreateProductCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductDto dto,
            [FromServices]IUpdateProductCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id,
            [FromServices]IDeleteProductCommand command)
        {
            _executor.ExecuteCommand(command, id);
        }
    }
}
