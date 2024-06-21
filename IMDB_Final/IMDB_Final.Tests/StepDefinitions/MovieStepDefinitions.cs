using IMDB.Services;
using IMDB.Services.ServiceInterfaces;
using IMDB_Final.Domain;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using System;
using TechTalk.SpecFlow;
using IMDB.Services.CustomExceptions.ActorExceptions;
using IMDB.Services.CustomExceptions.ProducerExceptions;
using IMDB.Services.CustomExceptions.MovieExceptions;
using System.Text.Json;
using IMDB.Repository.RepositoryInterfaces;
using IMDB.Repository;

namespace IMDB_Final.Tests.StepDefinitions
{
    [Binding]
    public class MovieStepDefinitions
    {
        private static IMovieService? _movieService;
        private static IActorService? _actorService;
        private static IProducerService? _producerService;
        private string _nameOfMovie;
        private int _movieId;
        private int _releaseYear;
        private string _plot;
        private List<int> _allActorIds;
        private int _producerId;
        private List<Movie> _allMovies;
        private string _exceptionMessage = string.Empty;

        public MovieStepDefinitions()
        {
            if (_actorService == null)
            {
                _actorService = new ActorService();
            }

            if (_producerService == null)
            {
                _producerService = new ProducerService();
            }

            if (_movieService == null)
            {
                _movieService = new MovieService(_actorService, _producerService);
            }
            
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            _actorService = new ActorService();
            _producerService = new ProducerService();

            List<Actor> actors = new List<Actor>
            {
                new Actor{Name = "Robert Downey Jr.", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{Name = "Leonardo Dicaprio", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{Name = "Zoe Saldana", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{Name = "Sam Worthington", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{Name = "Chris Evans", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{Name = "Christian bale", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{Name = "Heath Ledger", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{Name = "Scarlett Johhanson", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{Name = "Cillian Murphy", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{Name = "Matt LeBlanc", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{Name = "Chris Pratt", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{ Name = "Tom Holland", DateOfBirth=new DateOnly(1970, 12, 3)}
            };

            List<Producer> producers = new List<Producer>
            {
                new Producer{ Name = "Kevin Fiege", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "James Cameron", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "Quintin Tarantino", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "Karan Johar", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "Gauri Khan", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "Christopher Nolan", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "Tim Burton", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "Martin Scorsese", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "John Ford", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "David Fincher", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "Zoya Akhtar", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "Amir Khan", DateOfBirth = new DateOnly(1982, 1, 15) }
            };

            foreach (var actor in actors)
            {
                _actorService.AddActor(actor);
            }

            foreach (var producer in producers)
            {
                _producerService.AddProducer(producer);
            }
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            _movieService = new MovieService(_actorService, _producerService);

            List<Movie> movies = new List<Movie>
            {
                new Movie
                {
                    Name = "Shwashank Redemption",
                    Plot = "Two Imprisoned",
                    Year = 1994,
                    Actors = new List<Actor>
                    {
                        new Actor{Id = 13, Name = "Morgan Freeman", DateOfBirth = new DateOnly(1975, 4, 23) },
                        new Actor{Id = 14, Name = "Tim Robbins", DateOfBirth = new DateOnly(1975, 4, 23) }
                    },
                    Producer = new Producer { Id = 13, Name = "Frank Darabont", DateOfBirth = new DateOnly(1975, 2, 13)}
                },
                new Movie
                {
                    Name = "The Conjuring",
                    Plot = "Horror house",
                    Year = 2013,
                    Actors = new List<Actor>
                    {
                        new Actor{Id = 15, Name = "Patrick Wilson", DateOfBirth= new DateOnly(1993, 5, 5) },
                        new Actor{Id = 16, Name = "Vera Fermiga", DateOfBirth= new DateOnly(1993, 7, 5) }
                    },
                    Producer = new Producer {Id = 14, Name = "James Wan", DateOfBirth=new DateOnly(1986, 8, 21) }
                }
            };

            foreach (var movie in movies)
            {
                _movieService.AddMovie(movie);
            }
        }
        

        [Given(@"I have a movie named ""([^""]*)""")]
        public void GivenIHaveAMovieNamed(string name)
        {
            _nameOfMovie = name;
        }

        [Given(@"The release year of the movie is ""([^""]*)""")]
        public void GivenTheReleaseYearOfTheMovieIs(int p0)
        {
            _releaseYear = p0;
        }

        [Given(@"The plot of the movie is ""([^""]*)""")]
        public void GivenThePlotOfTheMovieIs(string p0)
        {
            _plot = p0;
        }

        [Given(@"the actors in the movie are ""([^""]*)""")]
        public void GivenTheActorsInTheMovieAre(string p0)
        {
            _allActorIds = p0.Split(',').Select(a => int.Parse(a)).ToList();
        }

        [Given(@"The Producer of the movie is ""([^""]*)""")]
        public void GivenTheProducerOfTheMovieIs(string p0)
        {
            _producerId = int.Parse(p0);
        }

        [When(@"I add the movie to IMDb")]
        public void WhenIAddTheMovieToIMDb()
        {
            try
            {
                _movieService.AddMovie(_nameOfMovie, _plot, _releaseYear, _allActorIds, _producerId);
            }
            catch (Exception ex)
            {
                _exceptionMessage = ex.Message;
            }
        }

        [Then(@"My movies in the IMDB console should look like this ""([^""]*)""")]
        public void ThenMyMoviesInTheIMDBConsoleShouldLookLikeThis(string p0)
        {
            var expectedValue = "";
            using (StreamReader r = new StreamReader("TestFiles/" + p0))
            {
                expectedValue = r.ReadToEnd();
            }
            _allMovies = _movieService.GetAllMovies();
            var actualValue = JsonSerializer.Serialize(_allMovies);

            var normalizedExpected = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(expectedValue));
            var normalizedActual = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(actualValue));

            Assert.Equal(normalizedExpected, normalizedActual);
        }


        [Then(@"Output message should be ""([^""]*)""")]
        public void ThenOutputMessageShouldBe(string p0)
        {
            Assert.Equal(p0, _exceptionMessage);
        }

        

        [When(@"I try to list all movies from the IMDB")]
        public void WhenITryToListAllMoviesFromTheIMDB()
        {
            _allMovies = _movieService.GetAllMovies();
        }

        [Then(@"My movies list should look like this ""([^""]*)""")]
        public void ThenMyMoviesListShouldLookLikeThis(string p0)
        {
            var expectedValue = "";
            using (StreamReader r = new StreamReader("TestFiles/" + p0))
            {
                expectedValue = r.ReadToEnd();
            }
            var actualValue = JsonSerializer.Serialize(_allMovies);

            var normalizedExpected = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(expectedValue));
            var normalizedActual = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(actualValue));

            Assert.Equal(normalizedExpected, normalizedActual);
        }

        [Given(@"I have an Id of a movie ""([^""]*)""")]
        public void GivenIHaveAnIdOfAMovie(string p0)
        {
            _movieId = int.Parse(p0);
        }

        [When(@"I delete this movie from IMDB")]
        public void WhenIDeleteThisMovieFromIMDB()
        {
            try
            {
                _movieService.DeleteMovie(_movieId);   
            }
            catch (Exception ex)
            {
                _exceptionMessage = ex.Message;
            }
        }

        
    }
}
