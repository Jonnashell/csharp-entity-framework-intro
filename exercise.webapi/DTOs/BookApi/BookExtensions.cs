using exercise.webapi.Models;

namespace exercise.webapi.DTOs.BookApi
{
    public static class BookExtensions
    {
        public static BookGet ToDTO(this Book entity)
        {
            AuthorExtGet author = new AuthorExtGet();
            author.Id = entity.AuthorId;
            author.FirstName = entity.Author.FirstName;
            author.LastName = entity.Author.LastName;
            author.Email = entity.Author.Email;

            PublisherExtGet bookPublisherGet = new PublisherExtGet();
            bookPublisherGet.Id = entity.Publisher.Id;
            bookPublisherGet.Name = entity.Publisher.Name;

            BookGet book = new BookGet();
            book.Title = entity.Title;
            book.Author = author;
            book.Publisher = bookPublisherGet;

            return book;
        }
    }
}