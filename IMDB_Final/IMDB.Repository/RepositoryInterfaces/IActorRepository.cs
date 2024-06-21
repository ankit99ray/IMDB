using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB_Final.Domain;
namespace IMDB.Repository.RepositoryInterfaces
{
    public interface IActorRepository
    {
        List<Actor> GetAllActors();

        List<int> GetAllActorIds();
        void AddActor(Actor actor);
        Actor GetActorById(int id);
        Actor GetActorByName(string name);
        void DeleteActors();

    }
}
