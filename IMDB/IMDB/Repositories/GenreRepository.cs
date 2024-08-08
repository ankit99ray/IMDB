using IMDB.Models.Db;
using IMDB.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace IMDB.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly string _connectionString;
        public GenreRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value.DefaultConnection;
        }


        public List<Genre> GetAllGenres()
        {
            var query = "SELECT * FROM Foundation.Genres";
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Genre>(query).ToList();
        }

        public Genre GetGenreById(int genreId)
        {
            var query = "SELECT * FROM Foundation.Genres WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Genre>(query, new { Id = genreId });
        }

        public int AddGenre(Genre genre)
        {
            var query = @"INSERT INTO Foundation.Genres (Name) VALUES (@Name);
                            SELECT @@Identity; ";
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<int>(query, new { Name = genre.Name });
        }

        public bool UpdateGenre(Genre genre)
        {
            var query = @"UPDATE Foundation.Genres SET Name = @Name WHERE Id = @Id";

            using var connection = new SqlConnection(_connectionString);
            connection.Execute(query, new
            {
                Id = genre.Id,
                Name = genre.Name
            });
            return true;
        }

        public bool RemoveGenre(int genreId)
        {
            var storedProcedure = "spDeleteGenreById";
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(storedProcedure, new { GenreId = genreId }, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Genre> GetGenresByMovieId(int movieId)
        {
            var query = @"SELECT G.* FROM Foundation.Genres G
                          INNER JOIN Foundation.Movies_Genres MG ON G.Id = MG.GenreId
                          WHERE MG.MovieId = @MovieId";
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Genre>(query, new { MovieId = movieId }).ToList();

        }
    }
}
