using BookAPIagro.Controllers.Utilities;
using BookAPIagro.DataStore;
using BookAPIagro.Entities;
using BookAPIagro.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace BookAPIagro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(BookServicesFacade.getAllBooks());
        }

        [HttpGet("{id}")]
        public IActionResult Get(uint id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(BookServicesFacade.getBookById(id));
        }

        [HttpGet("query")]
        public IActionResult Query([FromQuery] BookQuery bookQuery)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(BookQueryRunner.RunQuery(bookQuery).Select(book=> new BookDTO(book) ));
        }

    }
}
