using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Models.Db;
using IMDB.Repositories.Interfaces;
using Moq;

namespace IMDB.Tests.MockResources
{
    public class ReviewMock
    {
        public static readonly Mock<IReviewRepository> ReviewRepoMock = new Mock<IReviewRepository>();

        private static readonly List<Review> Reviews = new List<Review>() 
        {
            new Review()
            {
                Id = 1,
                MovieId = 1,
                ReviewMessage = "Review 1"
            },
            new Review()
            {
                Id = 2,
                MovieId = 2,
                ReviewMessage = "Review 2"
            },
            new Review()
            {
                Id = 3,
                MovieId = 1,
                ReviewMessage = "Review 3"
            },
            new Review()
            {
                Id = 4,
                MovieId = 2,
                ReviewMessage = "Review 4"
            }
        };
        
        public static void MockGetAllReviews()
        {
            ReviewRepoMock.Setup(x => x.GetAllReviews(It.IsAny<int>()))
                .Returns((int id) => Reviews.Where(r => r.MovieId == id).ToList());
        }
        public static void MockGetReviewById()
        {
            ReviewRepoMock.Setup(x => x.GetReviewById(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int id, int movieId) => Reviews.FirstOrDefault(r => r.Id == id && r.MovieId == movieId));
        }

        public static void MockAddReview()
        {
            ReviewRepoMock.Setup(x => x.AddReview(It.IsAny<Review>()))
                .Returns(Reviews.Max(r => r.Id) + 1);
        }
        public static void MockUpdateReview()
        {
            ReviewRepoMock.Setup(x => x.UpdateReview(It.IsAny<Review>())).Returns(true);
        }
        public static void MockDeleteReview()
        {
            ReviewRepoMock.Setup(x => x.RemoveReview(It.IsAny<int>())).Returns(true);
        }
    }
}
