using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB_Final.Domain;
using IMDB.Repository;
namespace IMDB.Services.ServiceInterfaces
{
    public interface IProducerService
    {
        List<Producer> GetAllProducers();
        List<int> GetAllProducerIds();
        Producer GetProducerById(int id);
        Producer GetProducerByName(string name);
        void AddProducer(string name, DateOnly birthDate);
        void AddProducer(Producer producer);
        void DeleteProducers();

    }
}
