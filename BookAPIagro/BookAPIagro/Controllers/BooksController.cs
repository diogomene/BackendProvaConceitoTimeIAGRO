using BookAPIagro.Controllers.Utilities;
using BookAPIagro.DataStore;
using BookAPIagro.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace BookAPIagro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("query")]
        public IActionResult Query([FromQuery] BookQuery bookQuery)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(BookQueryRunner.RunQuery(bookQuery));
        }

        [HttpGet("test")]
        public IActionResult Test() {
            var res = BookStore.GetInstance().StoreList.ToList();
            return Ok(res);
        }

    }
}
