using IMDB.Models.Request;
using IMDB.Models.Response;
using System.Collections.Generic;

namespace IMDB.Services.Interfaces
{
    public interface IActorService
    {
        List<ActorResponse> GetAllActors();
        ActorResponse GetActorById(int actorId);
        int AddActor(ActorRequest actor);
        bool UpdateActor(ActorRequest actor);
        bool DeleteActor(int actorId);

        List<ActorResponse> GetActorsByMovieId(int movieId);
    }
}
