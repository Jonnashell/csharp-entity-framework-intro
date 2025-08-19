using exercise.webapi.DTOs.BookApi;
using exercise.webapi.Models;
using exercise.webapi.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace exercise.webapi.Endpoints
{
    public static class BookApi
    {
        public static void ConfigureBooksApi(this WebApplication app)
        {
            app.MapGet("/books", GetBooks);
            app.MapGet("/books/{id}", GetBookById);
            app.MapPut("/books/{id}", Update);
            app.MapDelete("/books/{id}", Delete);
            app.MapPost("/books/{id}", Create);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IBookRepository bookRepository)
        {
            var entities = await bookRepository.GetAllBooks();

            List<BookGet> result = new List<BookGet>();
            foreach (var entity in entities)
            {
                result.Add(entity.ToDTO());
            }
            
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetBookById(IBookRepository bookRepository, int id)
        {
            var entity = await bookRepository.GetBook(id);
            if (entity == null)
            {
                return TypedResults.NotFound(new { Error = $"No book found with id '{id}'" });
            }

            return TypedResults.Ok(entity.ToDTO());
        }
        public static async Task<IResult> Update(IBookRepository bookRepository, IAuthorRepository authorRepository, int id, int authorId)
        {
            // Add NotFound Error
            Book entity = await bookRepository.GetBook(id);
            Author author = await authorRepository.GetAuthor(authorId);

            entity.AuthorId = authorId;
            entity.Author = author;

            await bookRepository.Update(id, entity);
            return TypedResults.Ok(entity.ToDTO());
        }
        public static async Task<IResult> Delete(IBookRepository bookRepository, int id)
        {
            // Add NotFound Error
            var entity = await bookRepository.Delete(id);
            return TypedResults.Ok(entity.ToDTO());
        }
        public static async Task<IResult> Create(IBookRepository bookRepository, BookPost model)
        {
            Book book = new Book();
            book.Title = model.Title;
            book.AuthorId = model.Author.Id;
            book.Author = model.Author;
            var entity = await bookRepository.Create(book);
            return TypedResults.Ok(entity.ToDTO());
        }
    }
}
