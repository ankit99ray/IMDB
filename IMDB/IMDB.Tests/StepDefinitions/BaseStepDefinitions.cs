using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

[assembly: CollectionBehavior(MaxParallelThreads = 1)]
namespace IMDB.Tests.StepDefinitions
{
    public class BaseStepDefinitions
    {

        protected WebApplicationFactory<TestStartup> Factory;
        protected HttpClient Client { get; set; }
        protected HttpResponseMessage Response { get; set; }

        public BaseStepDefinitions(WebApplicationFactory<TestStartup> baseFactory)
        {
            Factory = baseFactory;
        }

        [Given(@"I am a Client")]
        public void GivenIAmAClient()
        {
            Client = Factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"http://localhost")
            });
        }


        [When(@"I send a GET request to '([^']*)'")]
        public virtual async Task MakeGet(string resourceEndpoint)
        {
            var uri = new Uri(resourceEndpoint, UriKind.Relative);
            Response = await Client.GetAsync(uri);
        }


        [Then(@"I should get a response with status code '([^']*)'")]
        public void ResponseCompare(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, Response.StatusCode);
        }


        [Then(@"response data should look like '([^']*)'")]
        public void CompareResponse(string p0)
        {
            var expectedValue = "";
            using (StreamReader r = new StreamReader("TestFiles/Response/" + p0))
            {
                expectedValue = r.ReadToEnd();
            }
            var responseData = Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            var normalizedExpected = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(expectedValue));
            Assert.Equal(normalizedExpected, responseData);

            //var expectedValue = "";
            //using (StreamReader r = new StreamReader("TestFiles/Response/" + p0))
            //{
            //    expectedValue = r.ReadToEnd();
            //}

            //var responseData = Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            //var responseObject = JsonConvert.DeserializeObject(responseData);
            //var serializedResponseData = JsonConvert.SerializeObject(responseObject, Formatting.Indented);

            //var expectedObject = JsonConvert.DeserializeObject(expectedValue);
            //var serializedExpectedValue = JsonConvert.SerializeObject(expectedObject, Formatting.Indented);

            //Assert.Equal(serializedExpectedValue, serializedResponseData);
        }


        [When(@"I send a POST request to '([^']*)' with data '([^']*)'")]
        public virtual async Task MakePost(string resourceEndpoint, string postDataJson)
        {
            var postRelativeUri = new Uri(resourceEndpoint, UriKind.Relative);
            var content = "";
            using (StreamReader r = new StreamReader("TestFiles/Request/" + postDataJson))
            {
                content = r.ReadToEnd();
            }
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            Response = await Client.PostAsync(postRelativeUri, stringContent);
        }

        [When(@"I send a PUT request to '([^']*)' with data '([^']*)'")]
        public virtual async Task MakePut(string resourceEndPoint, string putDataJson)
        {
            var putRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            var content = "";
            using (StreamReader r = new StreamReader("TestFiles/Request/" + putDataJson))
            {
                content = r.ReadToEnd();
            }
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            Response = await Client.PutAsync(putRelativeUri, stringContent);
        }

        [When(@"I send a DELETE request to '([^']*)'")]
        public virtual async Task MakeDelete(string resourceEndPoint)
        {
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            Response = await Client.DeleteAsync(postRelativeUri);
        }

    }
}
