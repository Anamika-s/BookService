using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookService.Models;
namespace BookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // Web Api work on HTTP verbs
        // Get   > to get data froms service
        // Post  > send some data so the service
        // Put  > edit/update
        // Delete  > delete

        public static List<Book> books = null;
        public BookController()
        {
            if (books == null)
            {
                // List initializer
                books = new List<Book>()
                {
                    new Book(){ Id=100, BookName="C++", AuthorName="Author1", EditionNo=1, PublisherName="publisher1", PublishedDate=Convert.ToDateTime("12/12/2022")},

                    new Book(){ Id=101, BookName="Java", AuthorName="Author2", EditionNo=3, PublisherName="publisher2", PublishedDate=Convert.ToDateTime("12/12/2022")},

                    new Book(){ Id=102, BookName="C#", AuthorName="Author3", EditionNo=4, PublisherName="publisher3", PublishedDate=Convert.ToDateTime("12/12/2022")},


                    new Book(){ Id=103, BookName="Dotnet", AuthorName="Author4", EditionNo=1, PublisherName="publisher1", PublishedDate=Convert.ToDateTime("12/12/2022")}
                };

            }
        }
        [HttpGet]
        public List<Book> Get()
        {
            return books.ToList();

        }

        [HttpGet]
        [Route("{id:int}")]
        public Book GetBook(int id)
        {
            return books.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost]
        public void AddBook(Book book)
        {
            books.Add(book);

        }

        [HttpPut]
        [Route("{id}")]
        public void EditBook(int id, Book book)
        {
            Book temp = GetBook(id);
            if (temp != null)
            {
                    temp.PublishedDate = book.PublishedDate;
                    temp.PublisherName = book.PublisherName;
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteBook(int id)
        {
            Book temp = GetBook(id);
            if (temp != null)
            {
                books.Remove(temp);

            }
        }
    }
}