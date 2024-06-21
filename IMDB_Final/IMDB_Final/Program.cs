
using IMDB.Services;

namespace IMDB_Final
{
    public class Program
    {
        static void Main(string[] args)
        {
            var actorService = new ActorService();
            var producerService = new ProducerService();
            var movieService = new MovieService(actorService, producerService);


            Logo();

            while (true)
            {
                IntroductionMessage();
                var providedChoice = "";
                var isValidChoice = false;
                while(isValidChoice == false)
                {
                    providedChoice = Console.ReadLine();
                    if(string.IsNullOrWhiteSpace(providedChoice)) Console.WriteLine("\nChoice cannot be null or Empty.\nPlease enter a valid choice: ");
                    else if(int.TryParse(providedChoice, out _)==false) Console.WriteLine("\nAre you sure you entered a number as a choice?\nPlease try again and enter a valid choice: ");
                    else
                    {
                        isValidChoice = true;
                    }
                }
                var choice = int.Parse(providedChoice);

                switch (choice)
                {
                    case 1:
                        movieService.GetMovie();
                        break;
                    case 2:
                        movieService.AddMovie();
                        break;
                    case 3:
                        actorService.AddActor();
                        break;
                    case 4:
                        producerService.AddProducer();
                        break;
                    case 5:
                        movieService.DeleteMovie();
                        break;
                    case 6:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice! Choose Again");
                        break;
                }
                if (choice == 6) break;
            }

        }

        private static void IntroductionMessage()
        {
            Console.WriteLine("   ");
            Console.WriteLine(" Welcome to the IMDB Console!");
            Console.WriteLine(" Please choose an option (between 1 to 6):");
            Console.WriteLine(" 1. List Movies");
            Console.WriteLine(" 2. Add Movie");
            Console.WriteLine(" 3. Add Actor");
            Console.WriteLine(" 4. Add Producer");
            Console.WriteLine(" 5. Delete Movie");
            Console.WriteLine(" 6. Exit");
        }

        private static void Logo()
        {
            Console.WriteLine(" Welcome to");
            Console.WriteLine(@"
                                          
                                          ________  ____    ____  ____    _____
                                         |        ||    \  /    ||    \  |     \
                                         |__    __||     \/     ||     \ |  __  |
                                            |  |   |   |\  /|   ||  __  ||      |
                                            |  |   |   | \/ |   || |  | ||_____/
                                            |  |   |   |    |   || |__| ||     \
                                          __|  |__ |   |    |   ||      ||  __  |
                                         |        ||   |    |   ||     / |      |
                                         |________||___|    |___||____/  |_____/
                                         
                            ");
        }

    }
}
