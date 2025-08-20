using exercise.webapi.Models;

namespace exercise.webapi.DTOs.PublisherApi
{
    public static class PublisherExtensions
    {
        public static PublisherGet ToDTO(this Publisher entity)
        {

            PublisherGet publisher = new PublisherGet();
            publisher.Id = entity.Id;
            publisher.Name = entity.Name;

            foreach (var b in entity.Books)
            {
                AuthorExtGet author = new AuthorExtGet();
                author.Id = b.Author.Id;
                author.FirstName = b.Author.FirstName;
                author.LastName = b.Author.LastName;
                author.Email = b.Author.Email;

                BookExtGet book = new BookExtGet();
                book.Id = b.Id;
                book.Title = b.Title;
                book.Author = author;
                publisher.Books.Add(book);
            }

            return publisher;
        }
    }
}
