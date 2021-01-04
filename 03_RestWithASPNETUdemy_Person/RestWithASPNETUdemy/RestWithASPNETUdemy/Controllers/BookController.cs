using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNETUdemy.Repository;
using RestWithASPNETUdemy.Data.VO;

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
            var book = _bookBusiness.FindByID(id);
            if (book == null) return NotFound();

            return Ok(book); 
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookVO book)
        {
            if (book == null) return NotFound();

            return Ok(_bookBusiness.Create(book)); 
        }

        [HttpPut]
        public IActionResult Put([FromBody] BookVO book)
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
