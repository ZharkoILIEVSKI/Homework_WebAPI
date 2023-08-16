using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WebApplication1.DTO;
using WebApplication1.Mappers;
using WebApplication1.Models;
using WebApplication1.Models.Enum;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet("GetMovie/{id}")] 
        public IActionResult GetMovieById([FromRoute] int id)
        {
            if (id <= 0)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, $"The id must be positive.");
            }
            var movie = StaticDb.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie is null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Movie was not found.");
            };
            var movieDb = movie.MapMovieToMovieDto();
            return Ok(movie);
        }
        [HttpGet("All")]
        public IActionResult GetAll() 
        {
            var allMovie = StaticDb.Movies;
            return StatusCode(StatusCodes.Status200OK, allMovie);
        }

        [HttpGet("filterBy")]
        public IActionResult FilterBy([FromQuery] Genre genre, [FromQuery] int year) 
        {
            if (genre == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, "The genre of movie has to be selsected");
            }
            if (year <= 0)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "The year of movie has to be positive number");
            }
            var moviesFiltered = StaticDb.Movies.Where(x => x.Genre == genre && x.Year == year).ToList();
            return StatusCode(StatusCodes.Status200OK, moviesFiltered);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] MovieDto movieDto)
        {
            var newMovie = movieDto.MapMovieDtoToMovie();
            StaticDb.Movies.Add(newMovie);
            var updatedListOfMovies = StaticDb.Movies;
            return StatusCode(StatusCodes.Status200OK, updatedListOfMovies);
        }


        [HttpPut("Update")]
        public IActionResult Update([FromBody] MovieDto movieDto) 
        {
            var updatedMovie = StaticDb.Movies.FirstOrDefault(x => x.Id == movieDto.Id);
            
            if (updatedMovie is null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "The movie does not exist.");
            }

            updatedMovie.Title = movieDto.Title;
            updatedMovie.Year = movieDto.Year;
            updatedMovie.Description = movieDto.Description;
            updatedMovie.Genre = movieDto.Genre;

            return StatusCode(StatusCodes.Status200OK, StaticDb.Movies);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeletebyId([FromRoute] int id)
        {
            if (id <= 0) 
            {
                return StatusCode(StatusCodes.Status400BadRequest, "The id can not be negative.");
            }

            var movieForDeletion = StaticDb.Movies.FirstOrDefault(x => x.Id == id);
            if (movieForDeletion is null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"The movie with id {id} was not found");
            }
            StaticDb.Movies.Remove(movieForDeletion);
            return Ok($"The Movie '" + $"{movieForDeletion.Title}" + "' was deleted.");
        }
    }
}
