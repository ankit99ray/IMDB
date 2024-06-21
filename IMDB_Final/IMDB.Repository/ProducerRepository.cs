using IMDB.Repository.RepositoryInterfaces;
using IMDB_Final.Domain;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB_Final.Domain;
namespace IMDB.Repository
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly List<Producer> _producers;

        public ProducerRepository()
        {
            _producers = new List<Producer>();
        }
        public void AddProducer(Producer producer)
        {
            
            if (_producers.Count == 0)
            {
                producer.Id = 1;
            }
            else
            {
                var id = _producers.Max(p => p.Id);
                producer.Id = (id + 1);
            }
            _producers.Add(producer);
        }

        public List<int> GetAllProducerIds()
        {
            return _producers.Select(p => p.Id).ToList();
        }

        public List<Producer> GetAllProducers()
        {
            return _producers.ToList();
        }

        public Producer GetProducerById(int id)
        {
            return _producers.FirstOrDefault(p => p.Id == id);
        }

        public Producer GetProducerByName(string name)
        {
            return _producers.FirstOrDefault(p => p.Name == name);
        }

        public void DeleteProducers()
        {
            if (_producers.Count != 0)
            {
                _producers.Clear();
            }
        }
    }
}
