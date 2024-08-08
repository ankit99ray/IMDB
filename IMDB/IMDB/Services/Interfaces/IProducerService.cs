using IMDB.Models.Request;
using IMDB.Models.Response;
using System.Collections.Generic;

namespace IMDB.Services.Interfaces
{
    public interface IProducerService
    {
        List<ProducerResponse> GetAllProducers();
        ProducerResponse GetProducerById(int producerId);
        int AddProducer(ProducerRequest producer);
        bool UpdateProducer(ProducerRequest producer);
        bool DeleteProducer(int producerId);
    }
}
