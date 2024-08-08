using IMDB.Models.Db;
using System.Collections.Generic;

namespace IMDB.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        List<Review> GetAllReviews(int movieId);
        Review GetReviewById(int reviewId, int movieId);
        int AddReview(Review review);
        bool UpdateReview(Review review);
        bool RemoveReview(int reviewId);
    }
}
