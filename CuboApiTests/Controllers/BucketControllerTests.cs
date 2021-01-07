using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using CuboApi;
using CuboApi.Constants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace CuboApiTests.Controllers {

    public class BucketControllerTests {

        /*------------------------ FIELDS REGION ------------------------*/
        private const string PATH_BUCKET_CONTROLLER =
            Constants.API + Constants.SLASH + Constants.BUCKET;

        private const string PATH_PARAM_BUCKET_NAME =
            Constants.SLASH + Constants.PARAM_BUCKET_NAME;

        private const string BucketName = "First";

        private readonly TestServer _testServer;
        private readonly HttpClient _httpClient;

        /*------------------------ METHODS REGION ------------------------*/
        public BucketControllerTests() {
            _testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _httpClient = _testServer.CreateClient();
        }

        [Fact]
        public async Task GetAsync_ReturnEmptyCollection() {
            HttpResponseMessage response = await _httpClient.GetAsync(PATH_BUCKET_CONTROLLER);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<string> buckets =
                JsonConvert.DeserializeObject<IEnumerable<string>>(content);

            Assert.Empty(buckets);
        }

        [Fact]
        public async Task CreateBucket() {
            HttpResponseMessage response = await _httpClient.PostAsync(
                PATH_BUCKET_CONTROLLER + PATH_PARAM_BUCKET_NAME,
                GetPayload(new { })
            );

            response.EnsureSuccessStatusCode();
            Assert.Equal(response.StatusCode, HttpStatusCode.Created);
            Assert.Equal(
                response.Headers.Location.ToString(),
                Constants.BUCKET + "s" + PATH_PARAM_BUCKET_NAME
            );
        }

        private StringContent GetPayload(object data) {
            return new StringContent(
                JsonConvert.SerializeObject(data),
                Encoding.UTF8,
                MediaTypeNames.Application.Json
            );
        }

    }

}
