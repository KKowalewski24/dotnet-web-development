using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CuboApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace CuboApiTests.Controllers {

    public class BucketControllerTests {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly TestServer _testServer;
        private readonly HttpClient _httpClient;

        /*------------------------ METHODS REGION ------------------------*/
        public BucketControllerTests() {
            _testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _httpClient = _testServer.CreateClient();
        }

        [Fact]
        public async Task GetAsync_ReturnEmptyCollection() {
            HttpResponseMessage response = await _httpClient.GetAsync("api/bucket");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<string> buckets =
                JsonConvert.DeserializeObject<IEnumerable<string>>(content);

            Assert.Empty(buckets);
        }

    }

}
