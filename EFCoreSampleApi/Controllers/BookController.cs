using Core.Entity;
using Core.Input;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreSampleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            try
            {
                var books = _bookRepository.GetAll();
                return Ok(books);
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }

        }

        [HttpGet("{id:int}")]
        public IActionResult GetBookById([FromRoute] int id)
        {
            try
            {
                var book = _bookRepository.GetById(id);

                if (book == null)
                {
                    return NotFound();
                }

                return Ok(book);
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }

        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookInput bookInput)
        {
            try
            {
                var book = new Book()
                {
                    Name = bookInput.Name,
                    Publisher = bookInput.Publisher,
                };

                _bookRepository.Add(book);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        [HttpPut]
        public IActionResult UpdateBook([FromBody] BookUpdateInput bookInput)
        {
            try
            {
                var book = _bookRepository.GetById(bookInput.Id);
                book.Name = bookInput.Name;
                book.Publisher = bookInput.Publisher;

                _bookRepository.Update(book);
                return Ok(book);
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook([FromRoute] int id)
        {
            try
            {
                var book = _bookRepository.GetById(id);

                if (book == null)
                {
                    return NotFound();
                }

                _bookRepository.Delete(book.Id);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }   
    }
}
