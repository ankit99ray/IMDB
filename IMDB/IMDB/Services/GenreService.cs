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
    public class GenreService : IGenreService
    {
        private static IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public List<GenreResponse> GetAllGenre()
        {
            return _genreRepository.GetAllGenres().Select(g => new GenreResponse()
            {
                Name = g.Name,
                Id = g.Id
            }).ToList();
        }

        public GenreResponse GetGenreById(int genreId)
        {
            var genre = _genreRepository.GetGenreById(genreId);
            if (genre == null)
            {
                throw new NotFoundException("Genre not found");
            }

            return new GenreResponse()
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public int AddGenre(GenreRequest genre)
        {
            isValid(genre);
            return _genreRepository.AddGenre(new Genre()
            {
                Name = genre.Name
            });
        }

        public bool UpdateGenre(GenreRequest genre)
        {
            var curGenre = _genreRepository.GetGenreById(genre.Id);
            if (curGenre == null)
            {
                throw new NotFoundException("Genre not found");
            }

            isValid(genre);
            return _genreRepository.UpdateGenre(new Genre()
            {
                Id = genre.Id,
                Name = genre.Name
            });
        }

        public bool DeleteGenre(int genreId)
        {
            var genre = _genreRepository.GetGenreById(genreId);

            if (genre == null)
            {
                throw new NotFoundException("Genre not found");
            }

            return _genreRepository.RemoveGenre(genreId);
        }

        public List<GenreResponse> GetGenresByMovieId(int movieId)
        {
            return _genreRepository.GetGenresByMovieId(movieId).Select(g => new GenreResponse()
            {
                Id = g.Id,
                Name = g.Name
            }).ToList();
        }

        private bool isValid(GenreRequest genre)
        {
            if (genre == null)
            {
                throw new ArgumentNullException();
            }
            else if (string.IsNullOrWhiteSpace(genre.Name) || string.IsNullOrEmpty(genre.Name))
            {
                throw new ArgumentException("Genre name cannot be null or empty");
            }
            else return true;

        }
    }
}
