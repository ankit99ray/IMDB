using IMDB.Exceptions;
using IMDB.Models.Request;
using IMDB.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Firebase.Storage;

namespace IMDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = _movieService.GetAllMovies();
            return Ok(movies);

        }

        [HttpGet("{movieId:int}")]

        public IActionResult GetMovieById([FromRoute]int movieId)
        {
            try
            {
                return Ok(_movieService.GetMovieById(movieId));
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(new{error = e.Message});
            }
            catch (ArgumentException e)
            {
                return BadRequest(new{error = e.Message});
            }
            catch (NotFoundException e)
            {
                return NotFound(new{error = e.Message});
            }
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieRequest movie)
        {
            try
            {
                var newId = _movieService.AddMovie(movie);
                return Created($"~/api/movies/{newId}", newId);
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(new{error = e.Message});
            }
            catch (ArgumentException e)
            {
                return BadRequest(new{error = e.Message});
            }
            catch (NotFoundException e)
            {
                return NotFound(new{error = e.Message});
            }

        }

        [HttpPut("{movieId:int}")]
        public IActionResult UpdateMovie(int movieId, [FromBody] MovieRequest movie)
        {
            try
            {
                movie.Id = movieId;
                var answer = _movieService.UpdateMovie(movie);
                return Ok(new {isUpdated = answer});
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(new{error = e.Message});
            }
            catch (ArgumentException e)
            {
                return BadRequest(new{error = e.Message});
            }
            catch (NotFoundException e)
            {
                return NotFound(new{error = e.Message});
            }
        }

        [HttpDelete("{movieId}")]

        public IActionResult DeleteMovie(int movieId)
        {
            try
            {
                var answer = _movieService.DeleteMovie(movieId);
                return Ok(new {isDeleted = answer});
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(new{error = e.Message});
            }
            catch (ArgumentException e)
            {
                return BadRequest(new{error = e.Message});
            }
            catch (NotFoundException e)
            {
                return NotFound(new{error = e.Message});
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");
            var task = await new FirebaseStorage("imdb-d938d.appspot.com")
                .Child(Guid.NewGuid().ToString() + ".jpg")
                .PutAsync(file.OpenReadStream());
            return Ok(task);
        }

    }
}
