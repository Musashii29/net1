using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lecture10_Gr2.Controllers
{
    // BooksController which calls service methods

    [Route("api/[controller]")]
    [ApiController]
    public class WigniController : ControllerBase
    {
        // inject IBookService interface
        public readonly IBookService _bookService;

        public WigniController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("Wignebi")]
        public List<Wigni> GetBooks()
        {
            var books = _bookService.GetAllBooks();

            return books;
        }

        [HttpGet("Books/{id}")]
        public Wigni GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);

            return book;
        }

        [HttpGet("Books/ByAuthor/{author}")]
        public List<Wigni> GetBooksByAuthor([FromRoute] string author)
        {
            var booksByAuthor = _bookService.GetBooksByAuthor(author);
            return booksByAuthor;
        }

        [HttpGet("Books/ByName/{Title}")]
        public List<Wigni> GetBooksByTitle([FromRoute] string Title)
        {
            var booksByName = _bookService.GetBooksByTitle(Title);
            return booksByName;
        }

        [HttpPost("AddBook")]
        public void AddBook(Wigni book)
        {
            _bookService.AddBook(book);
        }

        [HttpPut("UpdateBook/{id}")]
        public void UpdateBook(int id, Wigni book)
        {
            _bookService.UpdateBook(id, book);
        }

        [HttpDelete("DeleteBook/{id}")]
        public void DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
        }

        [HttpPut("UpdateBookName/{currentTitle}")]
        public void UpdateBookName([FromRoute] string currentTitle, [FromBody] string newName)
        {
            _bookService.UpdateBookName(currentTitle, newName);
        }
    }
}