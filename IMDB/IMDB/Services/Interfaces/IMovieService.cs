using IMDB.Models.Request;
using IMDB.Models.Response;
using System.Collections.Generic;

namespace IMDB.Services.Interfaces
{
    public interface IMovieService
    {
        List<MovieResponse> GetAllMovies();
        MovieResponse GetMovieById(int movieId);
        int AddMovie(MovieRequest movie);
        bool UpdateMovie(MovieRequest movie);
        bool DeleteMovie(int movieId);
    }
}
