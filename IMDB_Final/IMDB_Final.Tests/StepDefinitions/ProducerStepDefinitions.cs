using IMDB.Services;
using IMDB.Services.ServiceInterfaces;
using IMDB_Final.Domain;
using System;
using TechTalk.SpecFlow;
using System.Text.Json;

namespace IMDB_Final.Tests.StepDefinitions
{
    [Binding]
    public class ProducerStepDefinitions
    {

        private static IProducerService? _producerService;
        private string _name;
        private DateOnly _dateOfBirth;
        private List<Producer> _allProducers;
        private string _exceptionMessage = string.Empty;

        public ProducerStepDefinitions()
        {
            if (_producerService == null)
            {
                _producerService = new ProducerService();
            }
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            _producerService = new ProducerService();
            

            List<Producer> producers = new List<Producer>
            {
                new Producer{Name = "Kevin Fiege", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "James Cameron", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "Quintin Tarantino", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "Karan Johar", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "Gauri Khan", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "Christopher Nolan", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "Tim Burton", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "Martin Scorsese", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "John Ford", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "David Fincher", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{Name = "Zoya Akhtar", DateOfBirth = new DateOnly(1982, 1, 15) },
                new Producer{ Name = "Amir Khan", DateOfBirth = new DateOnly(1982, 1, 15) }
            };

            foreach (var producer in producers)
            {
                _producerService.AddProducer(producer);
            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            _producerService.DeleteProducers();
        }

        [Given(@"I have a producer with name ""([^""]*)""")]
        public void GivenIHaveAProducerWithName(string p0)
        {
           _name = p0;
        }

        [Given(@"birth date of the producer is ""([^""]*)""")]
        public void GivenBirthDateOfTheProducerIs(string p0)
        {
            _dateOfBirth = DateOnly.Parse(p0);
        }

        [When(@"I add the producer to IMDB")]
        public void WhenIAddTheProducerToIMDB()
        {
            try
            {
                _producerService.AddProducer(_name, _dateOfBirth);
            }
            catch (Exception ex)
            {
                _exceptionMessage = ex.Message;
            }
        }

        [Then(@"My producers in the IMDB should look like this ""([^""]*)""")]
        public void ThenMyProducersInTheIMDBShouldLookLikeThis(string p0)
        {
            var expectedVal = "";
            using(StreamReader r = new StreamReader("TestFiles/" + p0))
            {
                expectedVal = r.ReadToEnd();
            }
            _allProducers = _producerService.GetAllProducers();
            var actualVal = JsonSerializer.Serialize(_allProducers);

            var normalizedExpected = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(expectedVal));
            var normalizedActual = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(actualVal));
            Assert.Equal(normalizedExpected, normalizedActual);
        }

        [Then(@"Output message should look something like ""([^""]*)""")]
        public void ThenOutputMessageShouldLookSomethingLike(string p0)
        {
            Assert.Equal(p0, _exceptionMessage);
        }
    }
}
