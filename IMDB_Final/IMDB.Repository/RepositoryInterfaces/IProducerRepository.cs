using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB_Final.Domain;
namespace IMDB.Repository.RepositoryInterfaces
{
    public interface IProducerRepository
    {

        List<Producer> GetAllProducers();
        Producer GetProducerById(int id);
        void AddProducer(Producer producer);
        List<int> GetAllProducerIds();
        Producer GetProducerByName(string name);
        void DeleteProducers();

    }
}
