using IMDB.Repository.RepositoryInterfaces;
using IMDB_Final.Domain;

namespace IMDB.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly List<Actor> _actors;
        public ActorRepository()
        {
            _actors = new List<Actor>();
        }
        public void AddActor(Actor actor)
        {
            
                if (_actors.Count == 0)
                {
                    actor.Id = 1;
                }
                else
                {
                    var id = _actors.Max(a => a.Id);
                    actor.Id = (id + 1);
                }

                _actors.Add(actor);
        }

        public Actor GetActorById(int id)
        {
            return _actors.FirstOrDefault(a => a.Id == id);
        }

        public Actor GetActorByName(string name)
        {
            return _actors.FirstOrDefault(a => a.Name == name);
        }

        public List<int> GetAllActorIds()
        {
            return _actors.Select(a => a.Id).ToList();
        }

        public List<Actor> GetAllActors()
        {
            return _actors.ToList();
        }

        public void DeleteActors()
        {
            if (_actors.Count != 0)
            {
                _actors.Clear();
            }
        }
    }
}
