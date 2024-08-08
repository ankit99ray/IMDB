using IMDB.Models.Request;
using IMDB.Models.Response;
using System.Collections.Generic;

namespace IMDB.Services.Interfaces
{
    public interface IGenreService
    {
        List<GenreResponse> GetAllGenre();
        GenreResponse GetGenreById(int genreId);
        int AddGenre(GenreRequest genre);
        bool UpdateGenre(GenreRequest genre);
        bool DeleteGenre(int genreId);

        List<GenreResponse> GetGenresByMovieId(int movieId);
    }
}
