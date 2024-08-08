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
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;
        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]

        public IActionResult GetAllActors()
        {
            var actors = _actorService.GetAllActors();
            return Ok(actors);

        }

        [HttpGet("{actorId:int}")]

        public IActionResult GetActorById(int actorId)
        {
            try
            {
                return Ok(_actorService.GetActorById(actorId));
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
        public IActionResult AddActor([FromBody] ActorRequest actor)
        {
            try
            {
                var newId = _actorService.AddActor(actor);
                return Created($"~/api/actors/{newId}", newId);
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

        [HttpPut("{actorId:int}")]
        public IActionResult UpdateActor(int actorId, [FromBody] ActorRequest actor)
        {
            try
            {
                actor.Id = actorId;
                var answer = _actorService.UpdateActor(actor);
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

        [HttpDelete("{actorId}")]

        public IActionResult DeleteActor(int actorId)
        {
            try
            {
                var answer = _actorService.DeleteActor(actorId);
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
    }
}
