using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB_Final.Domain;
namespace IMDB.Repository.RepositoryInterfaces
{
    public interface IMovieRepository
    {
        void AddMovie(Movie movie);
        List<Movie> GetAllMovies();
        void DeleteMovie(int id);
        Movie GetMovieByID(int id);
        Movie GetMovieByName(string name);
        void DeleteMovies();

    }
}
