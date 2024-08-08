using IMDB.Exceptions;
using IMDB.Models.Db;
using IMDB.Models.Request;
using IMDB.Models.Response;
using IMDB.Repositories.Interfaces;
using IMDB.Services.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;

namespace IMDB.Services
{
    public class ActorService : IActorService
    {
        private static IActorRepository _actorRepository;

        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public List<ActorResponse> GetAllActors()
        {
            return _actorRepository.GetAllActors().Select(a => new ActorResponse()
            {
                Id = a.Id,
                Bio = a.Bio,
                DateOfBirth = a.DateOfBirth,
                Gender = a.Gender,
                Name = a.Name
            }).ToList();
        }

        public ActorResponse GetActorById(int actorId)
        {
            var actor = _actorRepository.GetActorById(actorId);
            if (actor == null)
            {
                throw new NotFoundException("Actor not found");
            }
            var actorResponse = new ActorResponse()
            {
                Id = actor.Id,
                Bio = actor.Bio,
                DateOfBirth = actor.DateOfBirth,
                Gender = actor.Gender,
                Name = actor.Name
            };
            return actorResponse;
        }

        public int AddActor(ActorRequest actor)
        {
            isValid(actor);
            return _actorRepository.AddActor(new Actor()
            {
                Bio = actor.Bio,
                DateOfBirth = actor.DateOfBirth,
                Gender = actor.Gender,
                Name = actor.Name
            });
        }

        public bool UpdateActor(ActorRequest actor)
        {
            var curActor = _actorRepository.GetActorById(actor.Id);
            if (curActor == null)
            {
                throw new NotFoundException("Actor not found");
            }

            isValid(actor);
            return _actorRepository.UpdateActor(new Actor()
            {
                Id = actor.Id,
                Bio = actor.Bio,
                DateOfBirth = actor.DateOfBirth,
                Gender = actor.Gender,
                Name = actor.Name
            });
        }

        public bool DeleteActor(int actorId)
        {
            var actor = _actorRepository.GetActorById(actorId);
            if (actor == null)
            {
                throw new NotFoundException("Actor not found");
            }

            return _actorRepository.RemoveActor(actorId);
        }

        public List<ActorResponse> GetActorsByMovieId(int movieId)
        {
            return _actorRepository.GetActorsByMovieId(movieId).Select(a => new ActorResponse
            {
                Id = a.Id,
                Name = a.Name,
                DateOfBirth = a.DateOfBirth,
                Bio = a.Bio,
                Gender = a.Gender
            }).ToList();
        }

        private bool isValid(ActorRequest actor)
        {
            if (actor == null)
            {
                throw new ArgumentNullException();
            }
            else if (string.IsNullOrWhiteSpace(actor.Name))
            {
                throw new ArgumentException("actor name cannot be null or empty");
            }
            else if (string.IsNullOrWhiteSpace(actor.Bio))
            {
                throw new ArgumentException("actor bio cannot be null or empty");
            }
            else if ((actor.Gender.ToLower() != "male" && actor.Gender.ToLower() != "female") || string.IsNullOrWhiteSpace(actor.Gender))
            {
                throw new ArgumentException("actor gender cannot be other than male or female");
            }
            else if (actor.DateOfBirth.Year < 1900 || actor.DateOfBirth.Year > DateTime.Now.Year)
            {
                throw new ArgumentException("actor birth year cannot be less than 1900 or more than current year");
            }
            else
            {
                return true;
            }
        }
    }
}
