using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Services;
using IMDB.Services.Interfaces;
using IMDB.Tests.MockResources;
using Microsoft.Extensions.DependencyInjection;

namespace IMDB.Tests.StepDefinitions
{
    [Binding, Scope(Feature = "Movies")]
    public class MovieStepDefinitions : BaseStepDefinitions
    {
        public MovieStepDefinitions(CustomWebApplicationFactory factory)
            :base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => MovieMock.MovieRepoMock.Object);
                    services.AddScoped(_ => ProducerMock.ProducerRepoMock.Object);
                    services.AddScoped(_ => ActorMock.ActorRepoMock.Object);
                    services.AddScoped(_ => GenreMock.GenreRepoMock.Object);
                });
            }))
        {
            
        }

        [BeforeScenario]
        public static void Mocks()
        {
            MovieMock.MockGetAllMovies();
            MovieMock.MockGetMovieById();
            MovieMock.MockAddMovie();
            MovieMock.MockUpdateMovie();
            MovieMock.MockDeleteMovie();
            ActorMock.MockGetActorById();
            ActorMock.MockGetActorsByMovieId();
            ProducerMock.MockGetProducerById();
            GenreMock.MockGetGenreById();
            GenreMock.MockGetGenresByMovieId();
        }
    }
}
