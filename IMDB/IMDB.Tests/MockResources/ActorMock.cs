using IMDB.Models.Db;
using IMDB.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Tests.MockResources
{
    public class ActorMock
    {
        public static readonly Mock<IActorRepository> ActorRepoMock = new Mock<IActorRepository>();

        private static readonly List<Actor> Actors = new List<Actor>()
        {
            new Actor()
            {
                Id = 1,
                Name = "Actor1",
                Gender = "Male",
                DateOfBirth = new DateTime(1998,11,14),
                Bio = "Bio of Actor 1",
            },
            new Actor()
            {
                Id = 2,
                Name = "Actor2",
                Gender = "Female",
                DateOfBirth = new DateTime(1998,11,12),
                Bio = "Bio of Actor 2",
            }
        };

        public static void MockGetAllActors()
        {
            ActorRepoMock.Setup(x => x.GetAllActors()).Returns(Actors);
        }

        public static void MockGetActorById()
        {
            ActorRepoMock.Setup(x => x.GetActorById(It.IsAny<int>())).Returns((int id) => Actors.FirstOrDefault(a => a.Id == id));
        }

        public static void MockAddActor()
        {
            ActorRepoMock.Setup(x => x.AddActor(It.IsAny<Actor>())).Returns(Actors.Max(a => a.Id) + 1);
        }

        public static void MockUpdateActor()
        {
            ActorRepoMock.Setup(x => x.UpdateActor(It.IsAny<Actor>())).Returns(true);
        }

        public static void MockDeleteActor()
        {
            ActorRepoMock.Setup(x => x.RemoveActor(It.IsAny<int>())).Returns(true);
        }

        public static void MockGetActorsByMovieId()
        {
            ActorRepoMock.Setup(x => x.GetActorsByMovieId(It.IsAny<int>()))
                .Returns(Actors.Take(2).ToList());
        }
    }
}
