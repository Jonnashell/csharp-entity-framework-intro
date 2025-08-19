using exercise.webapi.Models;

namespace exercise.webapi.DTOs
{
    public class BookPost
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
