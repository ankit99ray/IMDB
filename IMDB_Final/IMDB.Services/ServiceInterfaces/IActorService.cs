using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Repository;
using IMDB_Final.Domain;
namespace IMDB.Services.ServiceInterfaces
{
    public interface IActorService
    {
        List<Actor> GetAllActors();
        Actor GetActorById(int id);
        List<int> GetAllActorIds();
        Actor GetActorByName(string name);
        void AddActor(string name, DateOnly birthDate);
        void AddActor(Actor actor);
        void DeleteActors();
    }
}
