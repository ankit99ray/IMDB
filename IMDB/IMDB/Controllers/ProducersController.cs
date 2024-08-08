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
    public class ProducersController : ControllerBase
    {
        private readonly IProducerService _producerService;
        public ProducersController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpGet]

        public IActionResult GetAllProducers()
        {
            var producers = _producerService.GetAllProducers();
            return Ok(producers);

        }

        [HttpGet("{producerId:int}")]

        public IActionResult GetProducerById(int producerId)
        {
            try
            {
                return Ok(_producerService.GetProducerById(producerId));
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
        public IActionResult AddProducer([FromBody] ProducerRequest producer)
        {
            try
            {
                var newId = _producerService.AddProducer(producer);
                return Created($"~/api/Producers/{newId}", newId);
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

        [HttpPut("{producerId:int}")]
        public IActionResult UpdateProducer(int producerId, [FromBody] ProducerRequest producer)
        {
            try
            {
                producer.Id = producerId;
                var answer = _producerService.UpdateProducer(producer);
                return Ok(new{isUpdated = answer});
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

        [HttpDelete("{producerId:int}")]

        public IActionResult DeleteProducer(int producerId)
        {
            try
            {
                var answer = _producerService.DeleteProducer(producerId);
                return Ok(new{isDeleted = answer});
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
