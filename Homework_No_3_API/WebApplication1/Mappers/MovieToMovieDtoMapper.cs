using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Mappers
{
    public static class MovieToMovieDtoMapper
    {
        public static MovieDto MapMovieToMovieDto(this Movie movie)
        {
            var movieDto = new MovieDto()
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Description = movie.Description,
                Year = movie.Year,
            };
            return movieDto;
        }
    }
}
