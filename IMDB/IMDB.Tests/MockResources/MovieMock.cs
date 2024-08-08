using IMDB.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Models.Db;

namespace IMDB.Tests.MockResources
{
    public class MovieMock
    {
        public static readonly Mock<IMovieRepository> MovieRepoMock = new Mock<IMovieRepository>();

        private static readonly List<Movie> Movies = new List<Movie>() 
        {
            new Movie()
            {
                Id = 1,
                Name = "Movie1",
                YearOfRelease = 1998,
                Plot = "Plot of Movie 1",
                PosterURL = "img.com/1",
                ProducerId = 1
            },
            new Movie()
            {
                Id = 2,
                Name = "Movie2",
                YearOfRelease = 1998,
                Plot = "Plot of Movie 2",
                PosterURL = "img.com/2",
                ProducerId = 2
            }
        };

        public static void MockGetAllMovies()
        {
            MovieRepoMock.Setup(x => x.GetAllMovies()).Returns(Movies);
        }

        public static void MockGetMovieById()
        {
            MovieRepoMock.Setup(x => x.GetMovieById(It.IsAny<int>()))
                .Returns((int id) => Movies.FirstOrDefault(m => m.Id == id));
        }

        public static void MockAddMovie()
        {
            MovieRepoMock.Setup(x => x.AddMovie(It.IsAny<Movie>(), It.IsAny<List<int>>(), It.IsAny<List<int>>()))
                .Returns(Movies.Max(m => m.Id) + 1);
        }

        public static void MockUpdateMovie()
        {
            MovieRepoMock.Setup(x => x.UpdateMovie(It.IsAny<Movie>(), It.IsAny<List<int>>(), It.IsAny<List<int>>()))
                .Returns(true);
        }

        public static void MockDeleteMovie()
        {
            MovieRepoMock.Setup(x => x.RemoveMovie(It.IsAny<int>())).Returns(true);
        }
    }
}
