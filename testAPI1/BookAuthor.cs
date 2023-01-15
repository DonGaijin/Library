using Microsoft.EntityFrameworkCore;

namespace testAPI1
{
    [Keyless]
    public class BookAuthor
    {
        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}