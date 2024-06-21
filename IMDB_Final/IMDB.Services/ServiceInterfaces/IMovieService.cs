using IMDB_Final.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Services.ServiceInterfaces
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        void AddMovie(string nameOfMovie, string plotOfMovie, int yearOfRelease, List<int> allActorIds, int producerId);
        void AddMovie(Movie movie);
        void DeleteMovie(int id);
        void DeleteMovies();

    }
}
