using IMDB.Repository.RepositoryInterfaces;
using IMDB_Final.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly List<Movie> _movies;
        public MovieRepository()
        {
            _movies = new List<Movie>();
        }
        public void AddMovie(Movie movie)
        {
            
            if (_movies.Count == 0)
            {
                movie.Id = 1;
            }
            else
            {
                var id = _movies.Max(m => m.Id);
                movie.Id = id + 1;
            }
            _movies.Add(movie);
        }

        public void DeleteMovie(int id)
        {
            _movies.RemoveAll(m => m.Id == id);
        }

        public List<Movie> GetAllMovies()
        {
            return _movies.ToList();
        }

        public Movie GetMovieByID(int id)
        {
            return _movies.FirstOrDefault(m => m.Id == id);
        }

        public Movie GetMovieByName(string name)
        {
            return _movies.FirstOrDefault(m => m.Name == name);
        }

        public void DeleteMovies()
        {
            if (_movies.Count != 0)
            {
                _movies.Clear();
            }
        }
    }
}
