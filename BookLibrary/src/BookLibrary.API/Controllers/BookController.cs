using BookLibrary.Domain.Events;
using BookLibrary.Domain.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.API.Controllers
{
    [Route("books")]
    [ApiController]
    public class BookController : ApiController
    {
        public BookController(IMediatorHandler mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            return Response(await Mediator.SendQuery(new SearchBooksQuery()));
        }
    }
}