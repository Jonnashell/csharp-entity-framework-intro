namespace exercise.webapi.DTOs
{
    public class BookExtGet
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AuthorExtGet Author { get; set; }
    }
}
