using IMDB.Exceptions;
using IMDB.Models.Db;
using IMDB.Models.Request;
using IMDB.Models.Response;
using IMDB.Repositories.Interfaces;
using IMDB.Services.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;

namespace IMDB.Services
{
    public class MovieService : IMovieService
    {
        private static IMovieRepository _movieRepository;
        private readonly IActorService _actorService;
        private readonly IGenreService _genreService;
        private readonly IProducerService _producerService;

        public MovieService(IMovieRepository movieRepository, IActorService actorService, IGenreService genreService, IProducerService producerService)
        {
            _movieRepository = movieRepository;
            _actorService = actorService;
            _genreService = genreService;
            _producerService = producerService;
        }
        public List<MovieResponse> GetAllMovies() 
        {
            return _movieRepository.GetAllMovies().Select(m => new MovieResponse()
            {
                Id = m.Id,
                Name = m.Name,
                YearOfRelease = m.YearOfRelease,
                Plot = m.Plot,
                PosterURL = m.PosterURL,
                Producer = _producerService.GetProducerById(m.ProducerId),
                Actors = _actorService.GetActorsByMovieId(m.Id),
                Genres = _genreService.GetGenresByMovieId(m.Id)

            }).ToList();
        }

        public MovieResponse GetMovieById(int movieId)
        {
            var movie = _movieRepository.GetMovieById(movieId);
            if (movie == null)
            {
                throw new NotFoundException("Movie not found");
            }

            return new MovieResponse()
            {
                Id = movie.Id,
                Name = movie.Name,
                YearOfRelease = movie.YearOfRelease,
                Plot = movie.Plot,
                PosterURL = movie.PosterURL,
                Producer = _producerService.GetProducerById(movie.ProducerId),
                Actors = _actorService.GetActorsByMovieId(movieId),
                Genres = _genreService.GetGenresByMovieId(movieId)
            };
        }

        public int AddMovie(MovieRequest movie)
        {
            IsValid(movie);
            return _movieRepository.AddMovie(new Movie()
            {
                Name = movie.Name,
                YearOfRelease = movie.YearOfRelease,
                Plot = movie.Plot,
                PosterURL = movie.PosterURL,
                ProducerId = movie.ProducerId

            }, movie.ActorIds, movie.GenreIds);
        }

        public bool UpdateMovie(MovieRequest movie)
        {
            var curMovie = _movieRepository.GetMovieById(movie.Id);
            if (curMovie == null)
            {
                throw new NotFoundException("Movie not found");
            }

            IsValid(movie);
            return _movieRepository.UpdateMovie(new Movie()
            {
                Id = movie.Id,
                Name = movie.Name,
                YearOfRelease = movie.YearOfRelease,
                Plot = movie.Plot,
                PosterURL = movie.PosterURL,
                ProducerId = movie.ProducerId

            }, movie.ActorIds, movie.GenreIds);
        }

        public bool DeleteMovie(int movieId)
        {
            var movie = _movieRepository.GetMovieById(movieId);
            if (movie == null)
            {
                throw new NotFoundException("Movie not found");
            }

            return _movieRepository.RemoveMovie(movieId);
        }

        private bool IsValid(MovieRequest movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException();
            }
            else if (string.IsNullOrWhiteSpace(movie.Name))
            {
                throw new ArgumentException("Movie name cannot be null or empty");
            }
            else if (string.IsNullOrWhiteSpace(movie.Plot))
            {
                throw new ArgumentException("Movie plot cannot be null or empty");
            }
            else if (string.IsNullOrWhiteSpace(movie.PosterURL))
            {
                throw new ArgumentException("Movie poster url cannot be null or empty");
            }
            else if (movie.YearOfRelease < 1900 || movie.YearOfRelease > DateTime.Now.Year)
            {
                throw new ArgumentException("Movie year of release cannot be less than 1900 and more than current year");
            }
            else if (_producerService.GetProducerById(movie.ProducerId) == null)
            {
                throw new ArgumentException("Producer not found");
            }
            else if (movie.ActorIds == null || movie.ActorIds.Count == 0)
            {
                throw new ArgumentException("Movie actor ids cannot be null or empty");
            }
            else if (movie.GenreIds == null || movie.GenreIds.Count == 0)
            {
                throw new ArgumentException("Movie genre ids cannot be null or empty");
            }
            else if (movie.ActorIds.Count != movie.ActorIds.Distinct().Count())
            {
                throw new ArgumentException("One movie cannot contain duplicate actor ids");
            }
            else if (movie.GenreIds.Count != movie.GenreIds.Distinct().Count())
            {
                throw new ArgumentException("One movie cannot contain duplicate genre ids");
            }

            foreach (var actorId in movie.ActorIds)
            {
                if (_actorService.GetActorById(actorId) == null)
                {
                    throw new NotFoundException("Actor not found");
                }
            }
            foreach (var genreId in movie.GenreIds)
            {
                if (_genreService.GetGenreById(genreId) == null)
                {
                    throw new NotFoundException("Genre not found");
                }
            }

            return true;
        }
    }
}
