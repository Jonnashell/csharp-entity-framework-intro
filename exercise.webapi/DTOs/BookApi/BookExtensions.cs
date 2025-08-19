using exercise.webapi.Models;

namespace exercise.webapi.DTOs.BookApi
{
    public static class BookExtensions
    {
        public static BookGet ToDTO(this Book entity)
        {
            BookAuthorGet author = new BookAuthorGet();
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