using BookService.DataContext;
using BookService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Book1Controller : ControllerBase
    {
        private BookDbContext _context;
        public Book1Controller(BookDbContext context)
        {
            _context = context;
        }

        public List<Book> Get()
        {
            return _context.Books.ToList();

        }

        [HttpPost]
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }

        [HttpPut("{id}")]

        public void EditBook(int id, Book book)
        {
            Book temp = Get(id);
            if (temp != null)
            {
                temp.PublisherName = book.PublisherName;
            }
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]

         public void DeleteBook(int id) {
            Book temp = Get(id);
            if (temp != null)
            {
                _context.Books.Remove(temp);
            }
            _context.SaveChanges();
        }
    }
}
