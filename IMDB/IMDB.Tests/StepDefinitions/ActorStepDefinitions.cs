using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Tests.MockResources;
using Microsoft.Extensions.DependencyInjection;

namespace IMDB.Tests.StepDefinitions
{
    [Binding, Scope(Feature = "Actors")]
    public class ActorStepDefinitions : BaseStepDefinitions
    {
        public ActorStepDefinitions(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => ActorMock.ActorRepoMock.Object);
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            ActorMock.MockGetAllActors();
            ActorMock.MockGetActorById();
            ActorMock.MockGetActorsByMovieId();
            ActorMock.MockAddActor();
            ActorMock.MockUpdateActor();
            ActorMock.MockDeleteActor();
        }
    }
}
