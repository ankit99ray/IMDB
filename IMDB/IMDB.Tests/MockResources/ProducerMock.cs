using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Models.Db;
using IMDB.Repositories.Interfaces;
using Moq;

namespace IMDB.Tests.MockResources
{
    public class ProducerMock
    {
        public static readonly Mock<IProducerRepository> ProducerRepoMock = new Mock<IProducerRepository>();

        private static readonly List<Producer> Producers = new List<Producer>()
        {
            new Producer()
            {
                Id = 1,
                Name = "Producer1",
                Gender = "Male",
                DateOfBirth = new DateTime(1998,11,14),
                Bio = "Bio of Producer 1",
            },
            new Producer()
            {
                Id = 2,
                Name = "Producer2",
                Gender = "Female",
                DateOfBirth = new DateTime(1998,11,12),
                Bio = "Bio of Producer 2",
            }
        };

        public static void MockGetAllProducers()
        {
            ProducerRepoMock.Setup(x => x.GetAllProducers()).Returns(Producers);
        }
        public static void MockGetProducerById()
        {
            ProducerRepoMock.Setup(x => x.GetProducerById(It.IsAny<int>()))
                .Returns((int id) => Producers.FirstOrDefault(p => p.Id == id));
        }
        public static void MockAddProducer()
        {
            ProducerRepoMock.Setup(x => x.AddProducer(It.IsAny<Producer>()))
                .Returns(Producers.Max(p => p.Id) + 1);
        }
        public static void MockUpdateProducer()
        {
            ProducerRepoMock.Setup(x => x.UpdateProducer(It.IsAny<Producer>())).Returns(true);
        }

        public static void MockDeleteProducer()
        {
            ProducerRepoMock.Setup(x => x.RemoveProducer(It.IsAny<int>())).Returns(true);
        }
    }
}
