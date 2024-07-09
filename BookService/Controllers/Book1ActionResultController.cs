using BookService.DataContext;
using BookService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Book1ActionResultController : ControllerBase
    {
        private BookDbContext _context;
        public Book1ActionResultController(BookDbContext context)
        {
            _context = context;
        }

        public ActionResult<List<Book>> Get()
        {
            if(_context.Books.ToList().Count==0)
            {
                return NotFound();
            }
            return _context.Books.ToList();

        }

        [HttpPost]
        public ActionResult<bool> AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            //return Created("Book added", book);
            return true;
        }

        [HttpGet("{id}")]
        public ActionResult<bool> Get(int id)
        {
            if (_context.Books.FirstOrDefault(x => x.Id == id) == null)
                return false;
            else
                return Ok(_context.Books.FirstOrDefault(x => x.Id == id));
        }

        [HttpPut("{id}")]

        public ActionResult<int> EditBook(int id, Book book)
        {
            Book temp = _context.Books.FirstOrDefault(x => x.Id == id);
            if (temp != null)
            {
                temp.PublisherName = book.PublisherName;
            }
            _context.SaveChanges();
            return 1;
        }

        [HttpDelete("{id}")]

         public ActionResult<bool> DeleteBook(int id) {
            Book temp = _context.Books.FirstOrDefault(x => x.Id == id);
            if (temp != null)

            {
                _context.Books.Remove(temp);

                _context.SaveChanges();
                return Ok("book has been deleted");
            }
            else
                return false;
        }
    }
}
