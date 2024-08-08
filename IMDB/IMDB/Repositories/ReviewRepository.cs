using IMDB.Models.Db;
using IMDB.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Options;

namespace IMDB.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly string _connectionString;
        public ReviewRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value.DefaultConnection;
        }

        public List<Review> GetAllReviews(int movieId)
        {
            var query = "SELECT * FROM Foundation.Reviews WHERE MovieId = @MovieId";
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Review>(query, new { MovieId = movieId }).ToList();
        }

        public Review GetReviewById(int reviewId, int movieId)
        {
            var query = "SELECT * FROM Foundation.Reviews WHERE Id = @ReviewId AND MovieId = @MovieId";
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Review>(query, new { ReviewId = reviewId, MovieId = movieId});
        }

        public int AddReview(Review review)
        {
            var query = @"INSERT INTO Foundation.Reviews (ReviewMessage, MovieId)
                            VALUES
                                (@ReviewMessage, @MovieId);
                                SELECT @@Identity";

            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<int>(query, new
            {
                ReviewMessage = review.ReviewMessage,
                MovieId = review.MovieId
            });
        }

        public bool UpdateReview(Review review)
        {
            var query = @"UPDATE Foundation.Reviews
                            SET 
                            MovieId = @MovieId, ReviewMessage = @ReviewMessage
                            WHERE Id = @Id";

            using var connection = new SqlConnection(_connectionString);
            connection.Execute(query, new
            {
                Id = review.Id,
                ReviewMessage = review.ReviewMessage,
                MovieId = review.MovieId
            });
            return true;
        }

        public bool RemoveReview(int reviewId)
        {
            var query = @"DELETE FROM Foundation.Reviews
                          WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(query, new { Id = reviewId });
            return true;
        }
    }
}
