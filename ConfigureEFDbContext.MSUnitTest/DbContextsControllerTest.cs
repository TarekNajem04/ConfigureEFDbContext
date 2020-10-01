using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ConfigureEFDbContext.MSUnitTest.Fixtures;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ConfigureEFDbContext.MSUnitTest
{
    [TestClass]
    public class DbContextsControllerTest
    {
        protected static IntegrationWebApplicationFactory _fixture;
        protected static HttpClient _client;
        protected readonly IConfiguration _configuration;

        /// <summary>
        /// Executes once for the test class. (Optional)
        /// </summary>
        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            _fixture = new IntegrationWebApplicationFactory();
            _client = _fixture.CreateClient();
            _client.BaseAddress = new Uri("http://localhost:60128");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Runs before each test. (Optional)
        /// </summary>
        [TestInitialize]
        public void Setup() { }

        /// <summary>
        /// Runs once after all tests in this class are executed. (Optional)
        /// Not guaranteed that it executes instantly after all tests from the class.
        /// </summary>
        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
            _client.Dispose();
            _fixture.Dispose();
        }

        /// <summary>
        /// Runs after each test. (Optional)
        /// </summary>
        [TestCleanup]
        public void TearDown() { }

        [TestMethod]
        public async Task DbContexts__Should_Initialized()
        {
            /*
             * ===== ===== ===== ===== ===== ===== ===== ===== ===== =====
             * Arrange
             * this is where you would typically prepare everything for the test,
             * in other words, prepare the scene for testing(creating the objects and setting them up as necessary)
             * ===== ===== ===== ===== ===== ===== ===== ===== ===== =====                   
             */
            var requestUri = new Uri("/DbContexts", UriKind.Relative);

            /*
             * ===== ===== ===== ===== ===== ===== ===== ===== ===== =====
             * Act
             * this is where the method we are testing is executed.
             * ===== ===== ===== ===== ===== ===== ===== ===== ===== =====
             */

            var response = await _client.GetAsync(requestUri).ConfigureAwait(false);
            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<List<string>>(responseBody);

            /*
            * ===== ===== ===== ===== ===== ===== ===== ===== ===== =====
            * Assert
            * This is the final part of the test where we compare what we expect to happen with the actual result of the test method execution.
            * ===== ===== ===== ===== ===== ===== ===== ===== ===== =====
            */

            Assert.IsNotNull(result);
        }
    }
}
