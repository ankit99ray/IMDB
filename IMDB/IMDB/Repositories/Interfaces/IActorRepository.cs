using IMDB.Models.Db;
using System.Collections.Generic;

namespace IMDB.Repositories.Interfaces
{
    public interface IActorRepository
    {
        List<Actor> GetAllActors();
        Actor GetActorById(int actorId);
        Actor GetActorByName(string actorName);
        List<int> GetAllActorIds();
        int AddActor(Actor actor);
        bool UpdateActor(Actor actor);
        bool RemoveActor(int actorId);

        List<Actor> GetActorsByMovieId(int movieId);

    }
}
