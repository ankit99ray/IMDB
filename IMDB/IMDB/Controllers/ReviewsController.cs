using IMDB.Exceptions;
using IMDB.Models.Request;
using IMDB.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.Controllers
{
    [Route("api/movies/{movieId:int}/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public IActionResult GetAllReviews(int movieId)
        {
            try
            {
                return Ok(_reviewService.GetAllReviews(movieId));
            }
            catch (System.ArgumentNullException e)
            {
                return BadRequest(new{error = e.Message});
            }
            catch (System.ArgumentException e)
            {
                return BadRequest(new{error = e.Message});
            }
            catch (NotFoundException e)
            {
                return NotFound(new{error = e.Message});
            }
        }

        [HttpGet("{reviewId:int}")]
        public IActionResult GetReviewById(int reviewId, int movieId)
        {
            try
            {
                return Ok(_reviewService.GetReviewById(reviewId, movieId));
            }
            catch (System.ArgumentNullException e)
            {
                return BadRequest(new{error = e.Message});
            }
            catch (System.ArgumentException e)
            {
                return BadRequest(new{error = e.Message});
            }
            catch (NotFoundException e)
            {
                return NotFound(new{error = e.Message});
            }
        }

        [HttpPost]
        public IActionResult AddReview([FromBody] ReviewRequest review, int movieId)
        {
            try
            {
                var newId = _reviewService.AddReview(review, movieId);
                return Created($"~/api/movies/{movieId}/reviews/{newId}", newId);
            }
            catch (System.ArgumentNullException e)
            {
                return BadRequest(new{error = e.Message});
            }
            catch (System.ArgumentException e)
            {
                return BadRequest(new{error = e.Message});
            }
            catch (NotFoundException e)
            {
                return NotFound(new{error = e.Message});
            }
        }

        [HttpPut("{reviewId:int}")]
        public IActionResult UpdateReview([FromBody] ReviewRequest review, int reviewId, int movieId)
        {
            try
            {
                review.Id = reviewId;
                var answer = _reviewService.UpdateReview(review, movieId);
                return Ok(new {isUpdated = true});
            }
            catch (System.ArgumentNullException e)
            {
                return BadRequest(new{error = e.Message});
            }
            catch (System.ArgumentException e)
            {
                return BadRequest(new{error = e.Message});
            }
            catch (NotFoundException e)
            {
                return NotFound(new{error = e.Message});
            }
        }

        [HttpDelete("{reviewId:int}")]
        public IActionResult DeleteReview(int reviewId, int movieId)
        {
            try
            {
                var answer = _reviewService.DeleteReview(reviewId, movieId);
                return Ok(new {isDeleted = true});
            }
            catch (System.ArgumentNullException e)
            {
                return BadRequest(new{error = e.Message});
            }
            catch (System.ArgumentException e)
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
