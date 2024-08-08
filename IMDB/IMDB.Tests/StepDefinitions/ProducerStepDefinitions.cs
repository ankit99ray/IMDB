using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Tests.MockResources;
using Microsoft.Extensions.DependencyInjection;

namespace IMDB.Tests.StepDefinitions
{
    [Binding, Scope(Feature = "Producers")]
    public class ProducerStepDefinitions : BaseStepDefinitions
    {
        public ProducerStepDefinitions(CustomWebApplicationFactory factory)
            :base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => ProducerMock.ProducerRepoMock.Object);
                });
            }))
        {
            
        }

        [BeforeScenario]

        public static void Mocks()
        {
            ProducerMock.MockAddProducer();
            ProducerMock.MockUpdateProducer();
            ProducerMock.MockGetAllProducers();
            ProducerMock.MockGetProducerById();
            ProducerMock.MockDeleteProducer();

        }
    }
}
