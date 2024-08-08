using IMDB.Models.Db;
using IMDB.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Data;

namespace IMDB.Repositories
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly string _connectionString;

        public ProducerRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value.DefaultConnection;
        }
        public List<Producer> GetAllProducers()
        {
            var query = "SELECT * FROM Foundation.Producers";
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Producer>(query).ToList();
        }

        public Producer GetProducerById(int producerId)
        {
            var query = "SELECT * FROM Foundation.Producers WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Producer>(query, new { Id = producerId });
        }

        public Producer GetProducerByName(string producerName)
        {
            var query = "SELECT * FROM Foundation.Producers WHERE Name = @Name";
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Producer>(query, new { Name = producerName });
        }

        public List<int> GetAllProducerIds()
        {
            var query = "SELECT Id FROM Foundation.Producers";
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<int>(query).ToList();
        }

        public int AddProducer(Producer producer)
        {
            var query = @"INSERT INTO Foundation.Producers
                          (Name, Gender, DateOfBirth, Bio)
                            VALUES
                           (@Name, @Gender, @DateOfBirth, @Bio);
                            SELECT @@Identity;";

            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<int>(query, new
            {
                Name = producer.Name,
                Gender = producer.Gender,
                DateOfBirth = producer.DateOfBirth,
                Bio = producer.Bio
            });
        }

        public bool UpdateProducer(Producer producer)
        {
            var query = @"UPDATE Foundation.Producers
                          SET
                            Name = @Name,
                            Gender = @Gender,
                            DateOfBirth = @DateOfBirth,
                            Bio = @Bio
                          WHERE Id = @Id";

            using var connection = new SqlConnection(_connectionString);
            connection.Execute(query, new
            {
                Id = producer.Id,
                Name = producer.Name,
                Gender = producer.Gender,
                DateOfBirth = producer.DateOfBirth,
                Bio = producer.Bio
            });
            return true;
        }

        public bool RemoveProducer(int producerId)
        {
            var storedProcedure = "spDeleteProducerById";
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(storedProcedure, new { ProducerId = producerId }, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
