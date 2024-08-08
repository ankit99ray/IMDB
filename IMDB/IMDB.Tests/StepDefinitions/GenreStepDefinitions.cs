using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Tests.MockResources;
using Microsoft.Extensions.DependencyInjection;

namespace IMDB.Tests.StepDefinitions
{
    [Binding, Scope(Feature = "Genres")]
    public class GenreStepDefinitions : BaseStepDefinitions
    {
        public GenreStepDefinitions(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => GenreMock.GenreRepoMock.Object);
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            GenreMock.MockGetAllGenres();
            GenreMock.MockGetGenresByMovieId();
            GenreMock.MockAddGenre();
            GenreMock.MockGetGenreById();
            GenreMock.MockUpdateGenre();
            GenreMock.MockDeleteGenre();
        }
    }
}
