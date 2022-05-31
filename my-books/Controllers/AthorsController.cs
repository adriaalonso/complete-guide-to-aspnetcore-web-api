using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthorsController : ControllerBase
    {
        private AuthorsService _authorsService;
        public AthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody]AuthorVM author)
        {
            _authorsService.AddAuthor(author);
            return Ok();
        }
    }
}
