namespace exercise.webapi.DTOs.PublisherApi
{
    public class PublisherGet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookExtGet> Books { get; set; } = new List<BookExtGet>();
    }
}
