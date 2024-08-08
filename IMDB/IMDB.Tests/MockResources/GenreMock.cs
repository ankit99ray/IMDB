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
    public class GenreMock
    {
        public static readonly Mock<IGenreRepository> GenreRepoMock = new Mock<IGenreRepository>();

        private static readonly List<Genre> Genres = new List<Genre>()
        {
            new Genre()
            {
                Id = 1,
                Name = "Genre1"
            },
            new Genre()
            {
                Id = 2,
                Name = "Genre2"
            },
            new Genre()
            {
                Id = 3,
                Name = "Genre3"
            }
        };

        public static void MockGetAllGenres()
        {
            GenreRepoMock.Setup(x => x.GetAllGenres()).Returns(Genres);
        }

        public static void MockGetGenreById()
        {
            GenreRepoMock.Setup(x => x.GetGenreById(It.IsAny<int>()))
                .Returns((int id) => Genres.FirstOrDefault(g => g.Id == id));
        }

        public static void MockAddGenre()
        {
            GenreRepoMock.Setup(x => x.AddGenre(It.IsAny<Genre>())).Returns(Genres.Max(g => g.Id) + 1);
        }

        public static void MockUpdateGenre()
        {
            GenreRepoMock.Setup(x => x.UpdateGenre(It.IsAny<Genre>())).Returns(true);
        }

        public static void MockDeleteGenre()
        {
            GenreRepoMock.Setup(x => x.RemoveGenre(It.IsAny<int>())).Returns(true);
        }

        public static void MockGetGenresByMovieId()
        {
            GenreRepoMock.Setup(x => x.GetGenresByMovieId(It.IsAny<int>()))
                .Returns(Genres.Take(2).ToList());
        }
    }
}
