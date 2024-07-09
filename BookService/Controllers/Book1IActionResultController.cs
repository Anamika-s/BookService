using BookService.DataContext;
using BookService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Book1IActionResultController : ControllerBase
    {
        private BookDbContext _context;
        public Book1IActionResultController(BookDbContext context)
        {
            _context = context;
        }

        public IActionResult Get()
        {
            if(_context.Books.ToList().Count==0)
            {
                return NotFound();
            }
            return Ok(_context.Books.ToList());

        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return Created("Book added", book);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if(_context.Books.FirstOrDefault(x => x.Id == id)==null)
               return NotFound();
            else 
            return Ok(_context.Books.FirstOrDefault(x => x.Id == id));
        }

        [HttpPut("{id}")]

        public IActionResult EditBook(int id, Book book)
        {
            Book temp = _context.Books.FirstOrDefault(x => x.Id == id);
            if (temp != null)
            {
                temp.PublisherName = book.PublisherName;
            }
            _context.SaveChanges();
            return Ok("book has been edited");
        }

        [HttpDelete("{id}")]

         public IActionResult DeleteBook(int id) {
            Book temp = _context.Books.FirstOrDefault(x => x.Id == id);
            if (temp != null)
            {
                _context.Books.Remove(temp);
            }
            _context.SaveChanges();
            return Ok("book has been deleted");
        }
    }
}
