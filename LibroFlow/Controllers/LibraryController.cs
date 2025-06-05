using LibroFlow.Application;
using LibroFlow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibroFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly LibraryService _service;

        public LibraryController(LibraryService service)
        {
            _service = service;
        }

        [HttpGet("books")]
        public IEnumerable<Book> GetBooks([FromServices] LibroFlow.Domain.Repositories.IBookRepository repo)
        {
            return repo.GetAll();
        }

        [HttpPost("loans")]
        public ActionResult<Loan> Borrow(Guid memberId, Guid bookId, int days = 14)
        {
            try
            {
                var loan = _service.BorrowBook(memberId, bookId, days);
                return Ok(loan);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("loans/{id}/return")]
        public IActionResult Return(Guid id)
        {
            try
            {
                _service.ReturnBook(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("loans/overdue")]
        public IEnumerable<Loan> Overdue()
        {
            return _service.CheckOverdue(DateTime.UtcNow);
        }
    }
}
