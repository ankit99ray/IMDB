using IMDB.Models.Db;
using System.Collections.Generic;

namespace IMDB.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
        Movie GetMovieById(int movieId);
        int AddMovie(Movie movie, List<int> actorIds, List<int> genreIds);
        bool UpdateMovie(Movie movie, List<int> actorIds, List<int> genreIds);
        bool RemoveMovie(int movieId);
        int GetProducerId(int movieId);
        List<int> GetActorIds(int movieId);
        List<int> GetGenreIds(int movieId);
    }
}
