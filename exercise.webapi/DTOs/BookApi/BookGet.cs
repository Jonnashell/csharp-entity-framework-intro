namespace exercise.webapi.DTOs.BookApi
{
    public class BookGet
    {
        public string Title { get; set; }
        public AuthorExtGet Author { get; set; }
        public PublisherExtGet Publisher { get; set; }
    }
}
