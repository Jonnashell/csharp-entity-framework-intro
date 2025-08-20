using System.Text.Json.Serialization;

namespace exercise.webapi.DTOs
{
    public class BookExtGet
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AuthorExtGet Author { get; set; }
    }
}
