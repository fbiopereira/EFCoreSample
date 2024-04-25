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
                var booksDto = new List<BookDto>();
                var books = _bookRepository.GetAll();

                foreach (var book in books)
                {
                    booksDto.Add(new BookDto()
                    {
                        Id = book.Id,
                        CreationDate = book.CreationDate,
                        Name = book.Name,
                        Publisher = book.Publisher,
                        Orders = book.Orders.Select(o => new Order()
                        {
                            Id = o.Id,
                            CreationDate = o.CreationDate,
                            ClientId = o.ClientId,
                            BookId = o.BookId,                           
                        }).ToList()
                    });
                }

                return Ok(booksDto);
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

        [HttpPost("bulkAdd")]
        public IActionResult BulkAddBook()
        {
            try
            {
                var books = new List<Book>()
                {
                    new Book() {Name = "Book 1", Publisher = "Publisher 1"},
                    new Book() {Name = "Book 2", Publisher = "Publisher 2"},
                    new Book() {Name = "Book 3", Publisher = "Publisher 3"},
                    new Book() {Name = "Book 4", Publisher = "Publisher 4"},
                    new Book() {Name = "Book 5", Publisher = "Publisher 5"},
                    new Book() {Name = "Book 6", Publisher = "Publisher 6"},
                    new Book() {Name = "Book 7", Publisher = "Publisher 7"},
                    new Book() {Name = "Book 8", Publisher = "Publisher 8"},
                    new Book() {Name = "Book 9", Publisher = "Publisher 9"},
                    new Book() {Name = "Book 10", Publisher = "Publisher 10"},                    
                };

                _bookRepository.BulkAdd(books);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        }


    }
}
