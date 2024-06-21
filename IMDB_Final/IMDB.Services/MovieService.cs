using IMDB.Repository;
using IMDB.Repository.RepositoryInterfaces;
using IMDB.Services.ServiceInterfaces;
using IMDB_Final.Domain;
using IMDB.Services.InputDetails;
using System.Security;
using System.Xml.Linq;
using IMDB.Services.CustomExceptions.MovieExceptions;
using IMDB.Services.CustomExceptions.ProducerExceptions;
using IMDB.Services.CustomExceptions.ActorExceptions;

namespace IMDB.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorService _actorService;
        private readonly IProducerService _producerService;

        public MovieService()
        {
            _movieRepository = new MovieRepository();
            _actorService = new ActorService();
            _producerService = new ProducerService();
        }

        public MovieService(IActorService actorService, IProducerService producerService)
        {
            _movieRepository = new MovieRepository();
            _actorService = actorService;
            _producerService = producerService;
        }

        //List Movie
        public void GetMovie()
        {
            if (GetAllMovies().Count == 0)
            {
                Console.WriteLine("No movies present till now.\nFirst add some movies.");
            }
            else
            {
                int providedChoice = InputMovieDetails.GetChoiceForListMovies();

                if (providedChoice == 1) //getting all movies
                {
                    var movies = GetAllMovies();

                    Console.WriteLine("The Movie and their details you are looking for are as follows: \n");
                    foreach (var movie in movies)
                    {
                        Console.WriteLine("********* ID : {0} *********", movie.Id);
                        Console.WriteLine("The name of the movie is: {0}", movie.Name);
                        Console.WriteLine("Plot of this movie is: {0}", movie.Plot);
                        Console.WriteLine("Year of release of the movie is: {0}", movie.Year);
                        Console.WriteLine("Actors in the movie are: {0}", string.Join(", ", movie.Actors.Select(a => a.Name).ToList().ToArray()));
                        Console.WriteLine("The producer of the movie is: {0}", movie.Producer.Name);
                        Console.WriteLine("****************************\n");
                    }

                }
                else if (providedChoice == 2) //Getting movie by ID
                {
                    var movies = GetAllMovies();
                    Console.WriteLine("Enter the Id to fetch the movie associated to the given id: ");
                    var providedId = "";
                    var isValidProvidedId = false;
                    while (isValidProvidedId == false)
                    {
                        providedId = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(providedId)) Console.WriteLine("Id cannot be null or empty.\nPlease try again and enter the valid Id: ");
                        else if (int.TryParse(providedId, out _) == false) Console.WriteLine("Are you sure you entered a number?\nPlease try again and enter the valid Id: ");
                        else if (_movieRepository.GetMovieByID(int.Parse(providedId)) == null) Console.WriteLine("Movie does not exist.\nPlease try again and enter the valid Id: ");
                        else
                        {
                            isValidProvidedId = true;
                        }
                    }
                    var movie = GetMovieById(int.Parse(providedId));
                    Console.WriteLine("\nThe name of the movie you are looking for is: {0} , with Id: {1}", movie.Name, movie.Id);
                    Console.WriteLine("Plot of this movie is: {0}", movie.Plot);
                    Console.WriteLine("Year of release of the movie is: {0}", movie.Year);
                    Console.WriteLine("Actors in the movie are: {0}", string.Join(", ", movie.Actors.Select(a => a.Name).ToList().ToArray()));
                    Console.WriteLine("The producer of the movie is: {0}", movie.Producer.Name);

                }
                else //Getting movie by Name
                {
                    var movies = GetAllMovies();
                    Console.WriteLine("Enter the name of the movie you want to fetch: ");
                    var providedName = "";
                    var isValidProvidedName = false;
                    while (isValidProvidedName == false)
                    {
                        providedName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(providedName)) Console.WriteLine("Name cannot be empty or null.\nPlease try agin and enter the valid name of the movie: ");
                        if (_movieRepository.GetMovieByName(providedName) == null) Console.WriteLine("Invalid name.\nPlease try agin and enter the valid name of the movie: ");
                        else
                        {
                            isValidProvidedName = true;
                        }
                    }
                    var movie = GetMovieByName(providedName);
                    Console.WriteLine("\nThe name of the movie is: {0}", movie.Name);
                    Console.WriteLine("The Id of the movie is: {0}", movie.Id);
                    Console.WriteLine("Plot of this movie is: {0}", movie.Plot);
                    Console.WriteLine("Year of release of the movie is: {0}", movie.Year);
                    Console.WriteLine("Actors in the movie are: {0}", string.Join(", ", movie.Actors.Select(a => a.Name).ToList().ToArray()));
                    Console.WriteLine("The producer of the movie is: {0}", movie.Producer.Name);

                }
            }
        }

        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAllMovies().ToList();
        }
        public Movie GetMovieById(int id)
        {
            var movie = _movieRepository.GetMovieByID(id);
            return (movie != null) ? movie : throw new MovieNotFoundException();
        }

        public Movie GetMovieByName(string name)
        {
            var movie = _movieRepository.GetMovieByName(name);
            return (movie != null) ? movie : throw new MovieNotFoundException();
        }


        //Adding Movie
        public void AddMovie()
        {
            if (_actorService.GetAllActors().Count == 0 && _producerService.GetAllProducers().Count == 0)
            {
                Console.WriteLine("Actors and Producers are not present in the database.\nFirst add some actors and producers.");
            }
            else if (_actorService.GetAllActors().Count == 0)
            {
                Console.WriteLine("Actors are not present in the database.\nFirst add some actors.");
            }
            else if (_producerService.GetAllProducers().Count == 0)
            {
                Console.WriteLine("Producers are not present in the database.\nFirst add some producers.");
            }
            else
            {
                string nameOfMovie = InputMovieDetails.GetMovieName();
                int yearOfRelease = InputMovieDetails.GetMovieReleaseYear();
                string plotOfMovie = InputMovieDetails.GetMoviePlot();
                List<int> allActorIds = InputMovieDetails.GetActorIds(_actorService);
                int producerId = InputMovieDetails.GetProducerId(_producerService);

                AddMovie(nameOfMovie, plotOfMovie, yearOfRelease, allActorIds, producerId);

                Console.WriteLine("Movie is added successfully. Given below are the details of the added movie: ");
                Console.WriteLine("Name of the movie is: {0}", nameOfMovie);
                Console.WriteLine("Year of release of the movie is: {0}", yearOfRelease);
                Console.WriteLine("Plot of the movie is: {0}", plotOfMovie);
                Console.WriteLine("Actors in the movie are: {0}", string.Join(", ", allActorIds.Select(a => _actorService.GetActorById(a).Name).ToList().ToArray()));
                Console.WriteLine("Producer of the movie is: {0}", _producerService.GetProducerById(producerId).Name);
            }
        }
        public void AddMovie(string nameOfMovie, string plotOfMovie, int yearOfRelease, List<int> allActorIds, int producerId)
        {
            if (IsValid(nameOfMovie, plotOfMovie, yearOfRelease, allActorIds, producerId))
            {
                var movie = new Movie
                {
                    Name = nameOfMovie,
                    Plot = plotOfMovie,
                    Year = yearOfRelease,
                    Actors = allActorIds.Select(actorId => _actorService.GetActorById(actorId)).ToList(),
                    Producer = _producerService.GetProducerById(producerId)
                };
                _movieRepository.AddMovie(movie);
            }
        }

        public void AddMovie(Movie movie)
        {
            _movieRepository.AddMovie(movie);
        }

        public bool IsValid(string name, string plot, int yearOfRelease, List<int> allActorIds, int producerId)
        {

            //if (_actorService.GetAllActors().Count == 0)
            //{
            //    throw new ActorNotFoundException();
            //}
            if (string.IsNullOrWhiteSpace(name)) throw new MovieNameEmptyException();
            else if (yearOfRelease < 1800 || yearOfRelease > DateTime.Now.Year) throw new MovieReleaseYearException();
            else if (string.IsNullOrWhiteSpace(plot)) throw new MoviePlotEmptyException();
            else if (_producerService.GetAllProducerIds().Contains(producerId) == false) throw new ProducerNotFoundException();
            else if (allActorIds == null || allActorIds.Count == 0) throw new ActorIdsEmptyException();
            else
            {
                foreach (var actorId in allActorIds)
                {
                    if (_actorService.GetAllActorIds().Contains(actorId) == false) throw new ActorNotFoundException();
                }
                return true;
            }
            
        }


        //Deleting Movie
        public void DeleteMovie()
        {
            var movies = GetAllMovies();
            if (movies.Count == 0)
            {
                Console.WriteLine("No movies are present int the database.\nFirst add some movies.");
            }
            else
            {
                Console.WriteLine("Following are the list of Movies: ");
                foreach (var movie in movies)
                {
                    Console.WriteLine("Id: {0}, Name: {1}", movie.Id, movie.Name);
                }
                Console.WriteLine("\nEnter the Id of the movie you want to delete: ");
                var providedId = "";
                var isValidProvidedId = false;
                while (isValidProvidedId == false)
                {
                    providedId = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(providedId)) Console.WriteLine("Id cannot be null or empty.\nPlease try again and enter the valid Id: ");
                    else if (int.TryParse(providedId, out _) == false) Console.WriteLine("Are you sure you entered a number?\nPlease try again and enter the valid Id: ");
                    else if (_movieRepository.GetMovieByID(int.Parse(providedId)) == null) Console.WriteLine("Movie does not exist.\nPlease try again and enter the valid Id: ");
                    else
                    {
                        isValidProvidedId = true;
                    }
                }
                var selectedMovie = GetMovieById(int.Parse(providedId));
                Console.WriteLine("Are you sure you want to delete the movie {0}");
                Console.WriteLine("Enter \"YES\" to delete the movie permanently OR Enter \"NO\" to cancel the process");
                var providedConfirmation = Console.ReadLine();
                while (providedConfirmation != "YES" && providedConfirmation != "NO")
                {
                    Console.WriteLine("Please enter a valid confirmation: ");
                    providedConfirmation = Console.ReadLine();
                }
                if (providedConfirmation == "YES")
                {
                    DeleteMovie(selectedMovie.Id);
                    Console.WriteLine("The Movie named {0} Deleted Successfully", selectedMovie.Name);
                }
                else
                {
                    Console.WriteLine("Movie deletion cancelled");
                }
            }
        }
        public void DeleteMovie(int id)
        {
            var movie = _movieRepository.GetMovieByID(id);
            if(movie == null)throw new MovieNotFoundException();
            else _movieRepository.DeleteMovie(id);
        }

        public void DeleteMovies()
        {
            _movieRepository.DeleteMovies();
        }
        
    }
}
