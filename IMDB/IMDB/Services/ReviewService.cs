using IMDB.Exceptions;
using IMDB.Models.Db;
using IMDB.Models.Request;
using IMDB.Models.Response;
using IMDB.Repositories.Interfaces;
using IMDB.Services.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;

namespace IMDB.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMovieService _movieService;

        public ReviewService(IReviewRepository reviewRepository, IMovieService movieService)
        {
            _reviewRepository = reviewRepository;
            _movieService = movieService;
        }
        public List<ReviewResponse> GetAllReviews(int movieId)
        {
            var movie = _movieService.GetMovieById(movieId);
            if (movie == null)
            {
                throw new NotFoundException("Movie not found");
            }
            return _reviewRepository.GetAllReviews(movieId).Where(r => r.MovieId == movieId).Select(r =>
                new ReviewResponse()
                {
                    Id = r.Id,
                    MovieId = r.MovieId,
                    ReviewMessage = r.ReviewMessage
                }).ToList();
        }

        public ReviewResponse GetReviewById(int reviewId, int movieId)
        {
            var movie = _movieService.GetMovieById(movieId);
            if (movie == null)
            {
                throw new NotFoundException("Movie not found");
            }

            var review = _reviewRepository.GetReviewById(reviewId, movieId);
            if (review == null)
            {
                throw new NotFoundException("Review not found");
            }

            return new ReviewResponse()
            {
                Id = review.Id,
                MovieId = review.MovieId,
                ReviewMessage = review.ReviewMessage
            };
        }

        public int AddReview(ReviewRequest review, int movieId)
        {
            var movie = _movieService.GetMovieById(movieId);
            if (movie == null)
            {
                throw new NotFoundException("Movie not found");
            }

            IsValid(review);
            return _reviewRepository.AddReview(new Review()
            {
                ReviewMessage = review.ReviewMessage,
                MovieId = review.MovieId
            });

        }

        public bool UpdateReview(ReviewRequest review, int movieId)
        {
            var movie = _movieService.GetMovieById(movieId);
            if (movie == null)
            {
                throw new NotFoundException("Movie not found");
            }

            var curReview = _reviewRepository.GetReviewById(review.Id, movieId);
            if (curReview == null)
            {
                throw new NotFoundException("Review not found");
            }
            IsValid(review);
            return _reviewRepository.UpdateReview(new Review()
            {
                Id = review.Id,
                MovieId = movieId,
                ReviewMessage = review.ReviewMessage

            });
        }

        public bool DeleteReview(int reviewId, int movieId)
        {
            var movie = _movieService.GetMovieById(movieId);
            if (movie == null)
            {
                throw new NotFoundException("Movie not found");
            }
            var review = _reviewRepository.GetReviewById(reviewId, movieId);
            if (review == null)
            {
                throw new NotFoundException("Review not found");
            }
            return _reviewRepository.RemoveReview(reviewId);
        }

        private bool IsValid(ReviewRequest review)
        {
            if (review == null)
            {
                throw new ArgumentNullException();
            }
            else if (string.IsNullOrWhiteSpace(review.ReviewMessage) || review.ReviewMessage == "")
            {
                throw new ArgumentException("Review message cannot be null or empty");
            }
            else
            {
                return true;
            }
        }
    }
}
