using exercise.webapi.DTOs;
using exercise.webapi.DTOs.AuthorApi;
using exercise.webapi.DTOs.BookApi;
using exercise.webapi.Models;
using exercise.webapi.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace exercise.webapi.Endpoints
{
    public static class AuthorApi
    {
        public static void ConfigureAuthorsApi(this WebApplication app)
        {
            app.MapGet("/authors/{id}", GetAuthorById);
            app.MapGet("/authors", GetAuthors);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAuthorById(IAuthorRepository authorRepository, int id)
        {
            var entity = await authorRepository.GetAuthor(id);
            if (entity == null)
            {
                return TypedResults.NotFound(new { Error = $"No author found with id '{id}'" });
            }
            
            return TypedResults.Ok(entity.ToDTO());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAuthors(IAuthorRepository authorRepository)
        {
            var entities = await authorRepository.GetAllAuthors();
            List<AuthorGet> result = new List<AuthorGet>();
            foreach (var entity in entities)
            {
                result.Add(entity.ToDTO());
            }

            return TypedResults.Ok(result);
        }
    }
}
