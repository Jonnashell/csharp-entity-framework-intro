using exercise.webapi.DTOs;
using exercise.webapi.DTOs.PublisherApi;
using exercise.webapi.Models;
using exercise.webapi.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace exercise.webapi.Endpoints
{
    public static class PublisherApi
    {
        public static void ConfigurePublishersApi(this WebApplication app)
        {
            app.MapGet("/publishers/{id}", GetPublisherById);
            app.MapGet("/publishers", GetPublishers);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPublisherById(IPublisherRepository publisherRepository, int id)
        {
            var entity = await publisherRepository.GetPublisher(id);
            if (entity == null)
            {
                return TypedResults.NotFound(new { Error = $"No publisher found with id '{id}'" });
            }

            return TypedResults.Ok(entity.ToDTO());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPublishers(IPublisherRepository publisherRepository)
        {
            var entities = await publisherRepository.GetAllPublishers();
            List<PublisherGet> result = new List<PublisherGet>();
            foreach (var entity in entities)
            {
                result.Add(entity.ToDTO());
            }

            return TypedResults.Ok(result);
        }
    }
}
