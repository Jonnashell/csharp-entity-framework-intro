using exercise.webapi.DTOs;
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

            return TypedResults.Ok(entity);
        }
    }
}
