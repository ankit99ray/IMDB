using IMDB.Models.Request;
using IMDB.Models.Response;
using System.Collections.Generic;

namespace IMDB.Services.Interfaces
{
    public interface IReviewService
    {
        List<ReviewResponse> GetAllReviews(int movieId);
        ReviewResponse GetReviewById(int reviewId, int movieId);
        int AddReview(ReviewRequest review, int movieId);
        bool UpdateReview(ReviewRequest review, int movieId);
        bool DeleteReview(int reviewId, int movieId);
    }
}
