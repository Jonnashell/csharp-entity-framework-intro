using exercise.webapi.Models;

namespace exercise.webapi.DTOs.AuthorApi
{
    public static class AuthorExtensions
    {
        public static AuthorGet ToDTO(this Author entity)
        {
            AuthorGet author = new AuthorGet();
            author.Id = entity.Id;
            author.FirstName = entity.FirstName;
            author.LastName = entity.LastName;
            author.Email = entity.Email;

            foreach (var book in entity.Books)
            {
                AuthorBookGet authorBook = new AuthorBookGet();
                authorBook.Id = book.Id;
                authorBook.Title = book.Title;
                author.Books.Add(authorBook);
            }

            return author;
        }
    }
}
