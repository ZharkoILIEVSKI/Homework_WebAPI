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
        [HttpGet("{id}")] 
        public IActionResult GetMovieById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Change an id property");
            }
            var movie = StaticDb.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie is null)
            {
                return BadRequest("Movie not found.");
            };
            var movieDb = movie.MapMovieToMovieDto();
            return Ok(movieDb);
        }
        [HttpGet("All")]
        public IActionResult GetAll() 
        {
            var allMovie = StaticDb.Movies;
            return Ok(allMovie);
        }

        [HttpGet("filterBy")]
        public IActionResult FilterBy([FromQuery] Genre genre, [FromQuery] int year) 
        {
            var moviesFiltered = StaticDb.Movies.Where(x => x.Genre == genre && x.Year == year).ToList();
            return Ok(moviesFiltered);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] MovieDto movieDto)
        {
            var newMovie = movieDto;
            StaticDb.Movies.Add(newMovie);
            var updatedListOfMovies = StaticDb.Movies;
            return Ok(updatedListOfMovies);
        }


        [HttpGet("Update")]
        public IActionResult Update(int id) 
        {
            var updatedMovie = StaticDb.Movies.FirstOrDefault(x => x.Id == id);
            return Ok(updatedMovie);
        }




    }
}
