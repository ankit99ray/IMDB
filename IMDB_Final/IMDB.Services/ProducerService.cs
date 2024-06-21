using IMDB.Repository;
using IMDB.Repository.RepositoryInterfaces;
using IMDB_Final.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Services.ServiceInterfaces;
using System.ComponentModel.DataAnnotations;
using IMDB.Services.CustomExceptions.ActorExceptions;
using IMDB.Services.CustomExceptions.ProducerExceptions;
using System.Numerics;
using IMDB.Services.InputDetails;
using System.Xml.Linq;
namespace IMDB.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        public ProducerService()
        {
            _producerRepository = new ProducerRepository();
        }

        public void AddProducer()
        {
            string name = InputProducerDetails.GetProducerName();
            DateOnly birthDate = InputProducerDetails.GetProducerBirthDate();
            
            AddProducer(name, birthDate);
            Console.WriteLine("Producer added successfully. ");
            Console.WriteLine("Name of the Producer added is: {0} \nDate of birth of the producer added is: {1}\n", name, birthDate.ToString());
            
        }

        public void AddProducer(string name, DateOnly birthDate)
        {
            if (IsValid(name, birthDate))
            {
                var producer = new Producer
                {
                    Name = name,
                    DateOfBirth = birthDate
                };
                _producerRepository.AddProducer(producer);
            }
        }

        public void AddProducer(Producer producer)
        {
            _producerRepository.AddProducer(producer);
        }

        public List<int> GetAllProducerIds()
        {
            return _producerRepository.GetAllProducerIds(); 
        }

        public List<Producer> GetAllProducers()
        {
            return _producerRepository.GetAllProducers();
        }

        public Producer GetProducerById(int id)
        {
            var producer = _producerRepository.GetProducerById(id);
            return (producer != null) ? producer : throw new ProducerNotFoundException();
        }

        public Producer GetProducerByName(string name)
        {
            var producer = _producerRepository.GetProducerByName(name);
            return (producer != null) ? producer : throw new ProducerNotFoundException();
        }

        public bool IsValid(string name, DateOnly birthDate)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ProducerNameEmptyException();
            else if (birthDate == null || birthDate.ToString() == "") throw new ProducerBirthDateEmptyException();
            else if (birthDate.Year > DateTime.Now.Year) throw new ProducerBirthDateInFutureException();
            else if (birthDate.Year == DateTime.Now.Year && birthDate.Month > DateTime.Now.Month) throw new ProducerBirthDateInFutureException();
            else if (birthDate.Year == DateTime.Now.Year && birthDate.Month == DateTime.Now.Month && birthDate.Day > DateTime.Now.Day) throw new ProducerBirthDateInFutureException();
            else if (birthDate.Year == 0 || birthDate.Month == 0 || birthDate.Day == 0) throw new ProducerBirthDateEmptyException();
            else if (birthDate.Year < 1800) throw new ProducerBirthDateTooOldException();
            else return true;
        }

        public void DeleteProducers()
        {
            _producerRepository.DeleteProducers();
        }
    }
}
