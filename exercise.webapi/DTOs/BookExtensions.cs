using exercise.webapi.Models;

namespace exercise.webapi.DTOs
{
    public static class BookExtensions
    {
        public static BookGet ToDTO(this Book entity)
        {
            AuthorGet author = new AuthorGet();
            author.Id = entity.AuthorId;
            author.FirstName = entity.Author.FirstName;
            author.LastName = entity.Author.LastName;
            author.Email = entity.Author.Email;

            BookGet book = new BookGet();
            book.Title = entity.Title;
            book.Author = author;

            return book;
        }
    }
}