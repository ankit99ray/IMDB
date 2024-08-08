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
    public class ActorRepository : IActorRepository
    {
        private readonly string _connectionString;

        public ActorRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value.DefaultConnection;
        }
        public List<Actor> GetAllActors()
        {
            var query = "SELECT * FROM Foundation.Actors";
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Actor>(query).ToList();
        }

        public Actor GetActorById(int actorId)
        {
            var query = "SELECT * FROM Foundation.Actors WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Actor>(query, new {Id = actorId});
        }

        public Actor GetActorByName(string actorName)
        {
            var query = "SELECT * FROM Foundation.Actors WHERE Name = @Name";
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Actor>(query, new { Name = actorName });
        }

        public List<int> GetAllActorIds()
        {
            var query = "SELECT Id FROM Foundation.Actors";
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<int>(query).ToList();
        }

        public int AddActor(Actor actor)
        {
            var query = @"INSERT INTO Foundation.Actors
                          (Name, Gender, DateOfBirth, Bio)
                            VALUES
                           (@Name, @Gender, @DateOfBirth, @Bio);
                            SELECT @@Identity;";

            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<int>(query, new
            {
                Name = actor.Name,
                Gender = actor.Gender,
                DateOfBirth = actor.DateOfBirth,
                Bio = actor.Bio
            });

        }

        public bool UpdateActor(Actor actor)
        {
            var query = @"UPDATE Foundation.Actors
                          SET
                            Name = @Name,
                            Gender = @Gender,
                            DateOfBirth = @DateOfBirth,
                            Bio = @Bio
                          WHERE Id = @Id";

            using var connection = new SqlConnection(_connectionString);
            connection.Execute(query, new
            {
                Id = actor.Id,
                Name = actor.Name,
                Gender = actor.Gender,
                DateOfBirth = actor.DateOfBirth,
                Bio = actor.Bio
            });
            return true;
        }

        public bool RemoveActor(int actorId)
        {
            var storedProcedure = "spDeleteActorById"; 
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(storedProcedure, new { ActorId = actorId }, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Actor> GetActorsByMovieId(int movieId)
        {
            var query = @"SELECT A.* FROM Foundation.Actors A
                        INNER JOIN Foundation.Movies_Actors MA
                        ON A.Id = MA.ActorId
                        WHERE MA.MovieId = @MovieId";
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Actor>(query, new { MovieId = movieId }).ToList();
        }
    }
}
