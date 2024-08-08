using IMDB.Exceptions;
using IMDB.Models.Request;
using IMDB.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IMDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]

        public IActionResult GetAllGenre()
        {
            var genres = _genreService.GetAllGenre();
            return Ok(genres);

        }

        [HttpGet("{genreId:int}")]

        public IActionResult GetgenreById(int genreId)
        {
            try
            {
                return Ok(_genreService.GetGenreById(genreId));
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
        public IActionResult AddGenre([FromBody] GenreRequest genre)
        {
            try
            {
                var newId = _genreService.AddGenre(genre);
                return Created($"~/api/genres/{newId}", newId);
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

        [HttpPut("{genreId:int}")]
        public IActionResult UpdateGenre(int genreId, [FromBody] GenreRequest genre)
        {
            try
            {
                genre.Id = genreId;
                var answer = _genreService.UpdateGenre(genre);
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

        [HttpDelete("{genreId:int}")]

        public IActionResult DeleteGenre(int genreId)
        {
            try
            {
                var answer = _genreService.DeleteGenre(genreId);
                return Ok(new { isDeleted = answer});
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
    }
}
