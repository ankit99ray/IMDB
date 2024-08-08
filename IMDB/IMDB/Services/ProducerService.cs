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
    public class ProducerService : IProducerService
    {
        private static IProducerRepository _producerRepository;

        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public List<ProducerResponse> GetAllProducers()
        {
            return _producerRepository.GetAllProducers().Select(p => new ProducerResponse()
            {
                Id = p.Id,
                Name = p.Name,
                Bio = p.Bio,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender
            }).ToList();
        }

        public ProducerResponse GetProducerById(int producerId)
        {
            var producer = _producerRepository.GetProducerById(producerId);
            if (producer == null)
            {
                throw new NotFoundException("Producer not found");
            }

            return new ProducerResponse()
            {
                Id = producer.Id,
                Name = producer.Name,
                Bio = producer.Bio,
                DateOfBirth = producer.DateOfBirth,
                Gender = producer.Gender
            };
        }

        public int AddProducer(ProducerRequest producer)
        {
            IsValid(producer);
            return _producerRepository.AddProducer(new Producer()
            {
                Name = producer.Name,
                Bio = producer.Bio,
                DateOfBirth = producer.DateOfBirth,
                Gender = producer.Gender
            });
        }

        public bool UpdateProducer(ProducerRequest producer)
        {
            var curProducer = _producerRepository.GetProducerById(producer.Id);
            if (curProducer == null)
            {
                throw new NotFoundException("Producer not found");
            }

            IsValid(producer);
            return _producerRepository.UpdateProducer(new Producer()
            {
                Id = producer.Id,
                Bio = producer.Bio,
                DateOfBirth = producer.DateOfBirth,
                Gender = producer.Gender,
                Name = producer.Name
            });
        }

        public bool DeleteProducer(int producerId)
        {
            var producer = _producerRepository.GetProducerById(producerId);
            if (producer == null)
            {
                throw new NotFoundException("Producer not found");
            }

            return _producerRepository.RemoveProducer(producerId);
        }

        private bool IsValid(ProducerRequest producer)
        {
            if (producer == null)
            {
                throw new ArgumentNullException();
            }
            else if (string.IsNullOrWhiteSpace(producer.Name))
            {
                throw new ArgumentException("producer name cannot be null or empty");
            }
            else if (string.IsNullOrWhiteSpace(producer.Bio))
            {
                throw new ArgumentException("producer bio cannot be null or empty");
            }
            else if ((producer.Gender.ToLower() != "male" && producer.Gender.ToLower() != "female") || string.IsNullOrWhiteSpace(producer.Gender))
            {
                throw new ArgumentException("producer gender cannot be other than male or female");
            }
            else if (producer.DateOfBirth.Year < 1900 || producer.DateOfBirth.Year > DateTime.Now.Year)
            {
                throw new ArgumentException("producer birth year cannot be less than 1900 or more than current year");
            }
            else
            {
                return true;
            }
        }
    }
}
