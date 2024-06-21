using IMDB.Services.ServiceInterfaces;
using IMDB_Final.Domain;
using IMDB.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Repository;
using IMDB.Services.CustomExceptions.ActorExceptions;
using IMDB.Services.InputDetails;

namespace IMDB.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorService()
        {
            _actorRepository = new ActorRepository();
        }

        public void AddActor()
        {
            string name = InputActorDetails.GetActorName();
            DateOnly birthDate = InputActorDetails.GetActorBirthDate();
            
                AddActor(name, birthDate);
                Console.WriteLine("Actor added successfully.");
                Console.WriteLine("Name of the actor is: {0}\nDate of birth of the actor is: {1}\n", name, birthDate.ToString());
            
        }

        public void AddActor(string name, DateOnly birthDate)
        {
            if (IsValid(name, birthDate))
            {
                var actor = new Actor
                {
                    Name = name,
                    DateOfBirth = birthDate
                };
                _actorRepository.AddActor(actor);
            }
        }

        public void AddActor(Actor actor)
        {
            _actorRepository.AddActor(actor);
        }

        public Actor GetActorById(int id)
        {
            var actor = _actorRepository.GetActorById(id);
            return (actor != null) ? actor : throw new ActorNotFoundException();
        }

        public Actor GetActorByName(string name)
        {
            var actor = _actorRepository.GetActorByName(name);
            return (actor != null) ? actor : throw new ActorNotFoundException();
        }

        public List<int> GetAllActorIds()
        {
            return _actorRepository.GetAllActorIds();
        }

        public List<Actor> GetAllActors()
        {
            return _actorRepository.GetAllActors();
        }

        public bool IsValid(string name, DateOnly birthDate)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ActorNameEmptyException();
            else if (birthDate == null || birthDate.ToString() == "") throw new ActorBirthDateEmptyException();
            else if (birthDate.Year > DateTime.Now.Year) throw new ActorBirthDateInFutureException();
            else if (birthDate.Year == DateTime.Now.Year && birthDate.Month > DateTime.Now.Month) throw new ActorBirthDateInFutureException();
            else if (birthDate.Year == DateTime.Now.Year && birthDate.Month == DateTime.Now.Month && birthDate.Day > DateTime.Now.Day) throw new ActorBirthDateInFutureException();
            else if (birthDate.Year == 0 || birthDate.Month == 0 || birthDate.Day == 0) throw new ActorBirthDateEmptyException();
            else if (birthDate.Year < 1800) throw new ActorBirthDateTooOldException();
            else return true;
        }

        public void DeleteActors()
        {
            _actorRepository.DeleteActors();
        }
    }
}
