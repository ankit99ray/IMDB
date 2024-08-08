using IMDB.Models.Db;
using System.Collections.Generic;

namespace IMDB.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        List<Genre> GetAllGenres();
        Genre GetGenreById(int genreId);
        int AddGenre(Genre genre);
        bool UpdateGenre(Genre genre);
        bool RemoveGenre(int genreId);

        List<Genre> GetGenresByMovieId(int movieId);
    }
}
