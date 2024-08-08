using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Tests.MockResources;
using Microsoft.Extensions.DependencyInjection;

namespace IMDB.Tests.StepDefinitions
{
    [Binding, Scope(Feature = "Reviews")]
    public class ReviewStepDefinitions : BaseStepDefinitions
    {
        public ReviewStepDefinitions(CustomWebApplicationFactory factory)
            :base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => ReviewMock.ReviewRepoMock.Object);
                    services.AddScoped(_ => MovieMock.MovieRepoMock.Object);
                    services.AddScoped(_ => ActorMock.ActorRepoMock.Object);
                    services.AddScoped(_ => ProducerMock.ProducerRepoMock.Object);
                    services.AddScoped(_ => GenreMock.GenreRepoMock.Object);
                });
            }))
        {
            
        }

        [BeforeScenario]

        public static void Mocks()
        {
            ReviewMock.MockGetAllReviews();
            ReviewMock.MockGetReviewById();
            ReviewMock.MockAddReview();
            ReviewMock.MockUpdateReview();
            ReviewMock.MockDeleteReview();
            MovieMock.MockGetMovieById();
            ActorMock.MockGetActorById();
            ActorMock.MockGetActorsByMovieId();
            ProducerMock.MockGetProducerById();
            GenreMock.MockGetGenreById();
            GenreMock.MockGetGenresByMovieId();
        }
    }
}
