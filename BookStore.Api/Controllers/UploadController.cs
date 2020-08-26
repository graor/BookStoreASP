using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DataAccess;
using BookStore.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public UploadController(BookStoreContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Post([FromForm] UploadDto dto)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(dto.Image.FileName);
            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "productImages", newFileName);

            using (var fileStrem = new FileStream(path, FileMode.Create))
            {
                dto.Image.CopyTo(fileStrem);
            }
            var pic = new ProductPic
            {
                src = path,
                alt = newFileName,
                ProductId=(int)dto.ProductId
            };
            _context.ProductPics.Add(pic);
            _context.SaveChanges();
        }

        public class UploadDto
        {
            public IFormFile Image { get; set; }
            public int ProductId { get; set; }
        }
    }
}
