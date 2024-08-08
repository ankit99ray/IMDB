using IMDB.Models.Db;
using IMDB.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Options;

namespace IMDB.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly string _connectionString;

        public MovieRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value.DefaultConnection;
        }
        public List<Movie> GetAllMovies()
        {
            var query = "SELECT * FROM Foundation.Movies;";
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Movie>(query).ToList();
        }

        public Movie GetMovieById(int movieId)
        {
            var query = "SELECT * FROM Foundation.Movies WHERE Id = @Id;";
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Movie>(query, new { Id = movieId });
        }

        public int AddMovie(Movie movie, List<int> actorIds, List<int> genreIds)
        {
            var storedProcedure = "spInsertMovie";
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<int>(storedProcedure, new
            {
                Name = movie.Name,
                ReleaseYear = movie.YearOfRelease,
                Plot = movie.Plot,
                PosterLink = movie.PosterURL,
                ActorIds = string.Join(",", actorIds),
                GenreIds = string.Join(",", genreIds),
                ProducerId = movie.ProducerId
            }, commandType: CommandType.StoredProcedure);

        }

        public bool UpdateMovie(Movie movie, List<int> actorIds, List<int> genreIds)
        {
            var storedProcedure = "spUpdateMovie";
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(storedProcedure, new
            {
                Id = movie.Id,
                Name = movie.Name,
                ReleaseYear = movie.YearOfRelease,
                Plot = movie.Plot,
                PosterLink = movie.PosterURL,
                ActorIds = string.Join(",", actorIds),
                GenreIds = string.Join(",", genreIds),
                ProducerId = movie.ProducerId
            }, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool RemoveMovie(int movieId)
        {
            var storedProcedure = "spDeleteMovieById";
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(storedProcedure, new { MovieId = movieId }, commandType: CommandType.StoredProcedure);
            return true;
        }

        public int GetProducerId(int movieId)
        {
            var query = "SELECT ProducerId FROM Foundation.Movies WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<int>(query, new { Id = movieId });
        }

        public List<int> GetActorIds(int movieId)
        {
            var query = @"SELECT am.ActorId FROM Foundation.Actors_Movies am
                            JOIN Foundation.Movies m ON am.MovieId = m.Id
                            WHERE am.MovieId = @MovieId";

            using var connection = new SqlConnection(_connectionString);
            return connection.Query<int>(query, new { MovieId = movieId }).ToList();


        }

        public List<int> GetGenreIds(int movieId)
        {
            var query = @"SELECT gm.GenreId FROM Foundation.Genres_Movies gm
                            JOIN Foundation.Movies m ON gm.MovieId = m.Id
                            WHERE gm.MovieId = @MovieId";

            using var connection = new SqlConnection(_connectionString);
            return connection.Query<int>(query, new { MovieId = movieId }).ToList();
        }
    }
}
