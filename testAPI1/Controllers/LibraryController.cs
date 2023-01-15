using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace testAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly DataContext context;

        public LibraryController(DataContext context)
        {
            this.context = context;
        }

        [HttpPost("create-an-author")]
        public async Task<ActionResult<List<Author>>> AddAuthor(Author author)
        {
            this.context.Author.Add(author);
            await this.context.SaveChangesAsync();
            return Ok(await this.context.Author.ToListAsync());
        }

        [HttpPost("Create a book")]
        public async Task<ActionResult<List<Book>>> AddBook(Book book)
        {
            this.context.Books.Add(book);
            await this.context.SaveChangesAsync();
            return Ok(await this.context.Books.ToListAsync());
        }

        [HttpGet("Read all books")]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            return Ok(await this.context.Books.ToListAsync());
        }

        [HttpGet("Read all authors")]
        public async Task<ActionResult<List<Author>>> GetAuthors()
        {
            return Ok(await this.context.Author.ToListAsync());
        }

        [HttpGet("author-search-by name")]
        public async Task<ActionResult<Author>> GetAuthor(string FirstName)
        {
            var Author = await this.context.Author.FindAsync(FirstName);
            //var Author = await this.context.Author.Where(A => A.FirstName == FirstName).ToListAsync<Author>;
            if (Author == null)
                return BadRequest("Author not found");
            return Ok(Author);
        }

        [HttpPut("Update a book")]
        public async Task<ActionResult<List<Book>>> UpdateBook(Book request)
        {
            var dbBook = await this.context.Books.FindAsync(request.Id);
            if (dbBook == null)
                return BadRequest("Book not found");

            dbBook.Title= request.Title;
            dbBook.Description= request.Description;
            dbBook.Rating= request.Rating;
            dbBook.ISBN= request.ISBN;
            dbBook.PublicationDate= request.PublicationDate;

            await this.context.SaveChangesAsync();
            return Ok(await this.context.Books.ToListAsync());
        }

        [HttpDelete("Delete a book")]
        public async Task<ActionResult<List<Book>>> Delete(int id)
        {
            var dbBook = await this.context.Books.FindAsync(id);
            if (dbBook == null)
                return BadRequest("Book not found");

            this.context.Books.Remove(dbBook);
            await this.context.SaveChangesAsync();
            return Ok(await this.context.Books.ToListAsync());
        }
    }
}
