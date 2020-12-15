using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNETUdemy.Repository;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BookController : ControllerBase
    {
        

        private readonly ILogger<BookController> _logger;
        private Business.IBookBusiness _bookBusiness;

        public BookController(ILogger<BookController> logger, Business.IBookBusiness bookBusiness)
        {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll()); 
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var Book = _bookBusiness.FindByID(id);
            if (Book == null) return NotFound();

            return Ok(Book); 
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null) return NotFound();

            return Ok(_bookBusiness.Create(book)); 
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            if (book == null) return NotFound();

            return Ok(_bookBusiness.Update(book)); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookBusiness.Delete(id);

            return NoContent(); 
        }

       

       
    }
}
