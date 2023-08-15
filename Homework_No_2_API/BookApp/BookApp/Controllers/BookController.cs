using BookApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Runtime.Intrinsics.X86;

namespace BookApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // Add GET method that returns all books
        [HttpGet("Books")] //https://localhost:7246/api/Book/Books
        public IActionResult GetAll()
        {
            var knigite = StaticDb.Books;
            return Ok(knigite);
        }

        // Add GET method that returns one book by sending index in the query string
        [HttpGet("queryString")] //https://localhost:7246/api/Book/Books/queryString?index=1
        public IActionResult GetbyIndex([FromQuery]int index) 
        {
            var getByIndex = StaticDb.Books[index];
            return Ok(getByIndex);
        }

        // Add GET method that returns one book by filtering by author and title(use query string parameters)
        [HttpGet("queryString2")]  //https://localhost:7246/api/Book/queryString2?author=Daniel%20Oljakovski&title=Segasnost
        public IActionResult GetbyFilter([FromQuery]string author, 
                                         [FromQuery]string title) 
        {
            var booksFromDb = StaticDb.Books.Where(book =>
            book.Author.ToLower().Contains(author.ToLower())
            && (string) book.Title == title).ToList();

            return Ok(booksFromDb);
        }
        // Add POST method that adds new book to the list of books(use the FromBody attribute)
        [HttpPost("PostNewBook")]
        public IActionResult PostNewBook([FromBody]Book book)
        {
            var newBook = book;
            StaticDb.Books.Add(newBook);
            return Ok(StaticDb.Books);
        }

        // BONUS
        // Add POST method that accepts list of books from the body of the request
        // and returns their titles as a list of strings.

        [HttpPost("BookToListOfString")]
        public ActionResult<List<string>> PostBookToStringList([FromBody] List<Book> books)
        {
            var newBook = new List<string>();
            foreach (var item in books)
            {
                newBook.Add(item.Title);
            }
            return Ok(newBook);
        }
    }
}
