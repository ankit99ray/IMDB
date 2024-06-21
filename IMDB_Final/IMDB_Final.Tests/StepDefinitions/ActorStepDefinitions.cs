using IMDB.Services;
using IMDB.Services.ServiceInterfaces;
using IMDB_Final.Domain;
using System;
using TechTalk.SpecFlow;
using System.Text.Json;
using IMDB.Services.CustomExceptions.ActorExceptions;

namespace IMDB_Final.Tests.StepDefinitions
{
    [Binding]
    public class ActorStepDefinitions
    {

        private static IActorService? _actorService;
        private string _name;
        private DateOnly _dateOfBirth;
        private string _exceptionMessage = string.Empty;
        private List<Actor> _allActors;

        public ActorStepDefinitions()
        {
            if (_actorService == null)
            {
                _actorService = new ActorService();
            }   
        }
        
        [BeforeScenario]
        public static void BeforeScenario()
        {
            _actorService = new ActorService();

            List<Actor> actors = new List<Actor>
            {
                new Actor{ Name = "Robert Downey Jr.", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{Name = "Leonardo Dicaprio", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{Name = "Zoe Saldana", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{Name = "Sam Worthington", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{Name = "Chris Evans", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{Name = "Christian bale", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{Name = "Heath Ledger", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{Name = "Scarlett Johhanson", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{Name = "Cillian Murphy", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{Name = "Matt LeBlanc", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{Name = "Chris Pratt", DateOfBirth=new DateOnly(1970, 12, 3)},
                new Actor{ Name = "Tom Holland", DateOfBirth=new DateOnly(1970, 12, 3)}
            };

            foreach (var actor in actors)
            {
                _actorService.AddActor(actor);
            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            _actorService.DeleteActors();
        }

        [Given(@"I have an actor named ""([^""]*)""")]
        public void GivenIHaveAnActorNamed(string p0)
        {
            _name = p0;
        }

        [Given(@"birth date of the actor is ""([^""]*)""")]
        public void GivenBirthDateOfTheActorIs(string p0)
        {
            _dateOfBirth = DateOnly.Parse(p0);
            
        }

        [When(@"I add the actor to IMDB")]
        public void WhenIAddTheActorToIMDB()
        {
            try
            {
                _actorService.AddActor(_name, _dateOfBirth);
            }
            catch (Exception ex)
            {
                _exceptionMessage = ex.Message;
            }
        }

        [Then(@"My actors in the IMDB should look like this ""([^""]*)""")]
        public void ThenMyActorsInTheIMDBShouldLookLikeThis(string p0)
        {
            var expectedValue = "";
            using (StreamReader r = new StreamReader("TestFiles/" + p0))
            {
                expectedValue = r.ReadToEnd();
            }
            _allActors = _actorService.GetAllActors();
            var actualValue = JsonSerializer.Serialize(_allActors);

            var normalizedExpected = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(expectedValue));
            var normalizedActual = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(actualValue));

            Assert.Equal(normalizedExpected, normalizedActual);
        }

        [Then(@"Output message should look like ""([^""]*)""")]
        public void ThenOutputMessageShouldLookLike(string p0)
        {
            Assert.Equal(p0, _exceptionMessage);
        }
    }
}
