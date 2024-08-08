using IMDB.Models.Db;
using System.Collections.Generic;

namespace IMDB.Repositories.Interfaces
{
    public interface IProducerRepository
    {
        List<Producer> GetAllProducers();
        Producer GetProducerById(int producerId);
        Producer GetProducerByName(string producerName);
        List<int> GetAllProducerIds();
        int AddProducer(Producer producer);
        bool UpdateProducer(Producer producer);
        bool RemoveProducer(int producerId);
    }
}
