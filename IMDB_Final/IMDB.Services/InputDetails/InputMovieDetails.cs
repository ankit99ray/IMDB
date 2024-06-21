using IMDB.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Services.InputDetails
{
    public class InputMovieDetails
    {
        //Getting name of the movie to be added
        public static string GetMovieName()
        {

            Console.WriteLine("Enter the name of the movie you want to add: ");
            var providedMovieName = Console.ReadLine();
            while(string.IsNullOrWhiteSpace(providedMovieName))
            {
                Console.WriteLine("Movie name cannot be null or empty. Please Enter a valid movie name: ");
                providedMovieName = Console.ReadLine();
            }
            return providedMovieName;
        }

        //Selecting Actors for the Movie from the available actors
        public static List<int> GetActorIds( IActorService _actorService)
        {

            var allActors = _actorService.GetAllActors();
            Console.WriteLine("******* Actor Selection for the movie ****** \n");
            foreach (var actor in allActors)
            {
                Console.WriteLine("ID: {0}, Name: {1}", actor.Id, actor.Name);
            }
            Console.WriteLine("Enter the Ids of actors from the above actors you want to cast in the movie, separated by a comma (,) : ");
            var providedActorIds = "";
            var isValidActorIds = false;
            var selectedActorIds = new List<int>();
            while(isValidActorIds == false)
            {
                providedActorIds = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(providedActorIds))
                {
                    Console.WriteLine("Actor Ids cannot be null or empty. Please enter valid Ids of actors separated by a comma (,) : ");
                }
                else
                {
                    var providedActorIdsArray = providedActorIds.Split(',').ToArray();
                    foreach (var actorId in providedActorIdsArray)
                    {
                        if(int.TryParse(actorId, out _))
                        {
                            var actor = allActors.FirstOrDefault(a => a.Id == int.Parse(actorId));
                            if(actor != null)
                            {
                                selectedActorIds.Add(actor.Id);
                            }

                        }
                    }
                    if(selectedActorIds.Count == providedActorIdsArray.Length)
                    {
                        isValidActorIds = true; 
                    }
                    else
                    {
                        Console.WriteLine("{0} number of actors are not valid. Please enter the Ids again separated by a comma (,) : ");
                        selectedActorIds = new List<int>();
                    }
                }
            }
            var selectedActorsNames = string.Join(", ", selectedActorIds.Select(a => _actorService.GetActorById(a).Name).ToList());
            Console.WriteLine("Your selected Actors are: {0}", selectedActorsNames);
            return selectedActorIds;
        }


        //Getting the plot of the movie
        public static string GetMoviePlot()
        {
            Console.WriteLine("Write the plot of the movie: ");
            var providedPlotOfTheMovie = "";
            var isValidPlot = false;
            while(isValidPlot == false)
            {
                providedPlotOfTheMovie = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(providedPlotOfTheMovie))
                {
                    Console.WriteLine("Plot of the movie cannot be null or empty. Please enter a valid plot of the movie");
                }
                else if(providedPlotOfTheMovie.Split(' ').ToArray().Length < 2)
                {
                    Console.WriteLine("Plot of the movie is too short. Please enter a valid plot of the movie: ");
                }
                else
                {
                    isValidPlot = true;
                }
            }
            return providedPlotOfTheMovie;
        }


        //Getting the release year of the movie
        public static int GetMovieReleaseYear()
        {
            Console.WriteLine("Enter the release year of the movie: ");
            var proviedReleaseYear = "";
            var isValidReleaseYear = false;
            while(isValidReleaseYear == false)
            {
                proviedReleaseYear = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(proviedReleaseYear))
                {
                    Console.WriteLine("Release year of the movie cannot be null or empty.\nPlease try again and enter a valid release year of the movie: ");
                }
                if(int.TryParse(proviedReleaseYear, out _) == false)
                {
                    Console.WriteLine("Are you sure you are entering numbers?\nPlease enter a valid release year of the movie: ");
                }
                else if (int.Parse(proviedReleaseYear) > DateTime.Now.Year)
                {
                    Console.WriteLine("This movie is not released yet.\nPlease try again and enter a valid release year of the movie: ");
                }
                else if(int.Parse(proviedReleaseYear) < 1918)
                {
                    Console.WriteLine("How exactly did your movie got filmed before the camera was invented?\nPlease try again and enter a valid release year of the movie:  ");
                }
                else
                {
                    isValidReleaseYear = true;
                }

            }
            return int.Parse(proviedReleaseYear);
        }

        public static int GetProducerId(IProducerService _producerService)
        {
            Console.WriteLine("****** Producer Selection for the Movie ******");
            var allProducers = _producerService.GetAllProducers();
            foreach ( var producer in allProducers )
            {
                Console.WriteLine("ID: {0}, Name: {1}", producer.Id, producer.Name);
            }
            Console.WriteLine("\nEnter the ID of the producer from the above list for the movie: ");
            var providedProducerId = "";
            var isValidProducerId = false;
            while( isValidProducerId == false)
            {
                providedProducerId = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(providedProducerId))
                {
                    Console.WriteLine("Producer Id cannot be null or empty.\nPlease try again and enter the valid producer id: ");
                }
                else if(int.TryParse(providedProducerId, out _) == false)
                {
                    Console.WriteLine("Are you sure you entered an integer?\nPlease try again and enter the valid producer id: ");
                }
                else if(allProducers.FirstOrDefault(p => p.Id == int.Parse(providedProducerId)) == null)
                {
                    Console.WriteLine("Producer whose producer id is {0} does not exist.\nPlease try again and enter the valid producer id: ", providedProducerId);
                }
                else
                {
                    isValidProducerId = true;
                }
            }
            var selectedProducerName = allProducers.FirstOrDefault(p => p.Id == int.Parse(providedProducerId)).Name;
            Console.WriteLine("Your selected producer is: {0}\n", selectedProducerName);
            return int.Parse(providedProducerId);
        }

        public static int GetChoiceForListMovies()
        {
            Console.WriteLine("Enter the choice how do you want to list the movies: ");
            Console.WriteLine("1. List All Movies\n2. List movie by the Id\n3. List Movie by name");
            var providedInput = "";
            var isValidProvidedInput = false;
            while (isValidProvidedInput == false)
            {
                providedInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(providedInput))
                {
                    Console.WriteLine("Choice cannot be null or empty.\nPlease try again and enter the valid choice: ");
                }
                else if (int.TryParse(providedInput, out _) == false)
                {
                    Console.WriteLine("Are you sure you entered a number?.\nPlease try again and enter the valid choice: ");
                }
                else if (int.Parse(providedInput) <= 0 || int.Parse(providedInput) > 3)
                {
                    Console.WriteLine("Invalid choice provided.\nPlease try again and enter the valid choice: ");
                }
                else
                {
                    isValidProvidedInput = true;
                }
            }
            return int.Parse(providedInput);
        }
    }
}
