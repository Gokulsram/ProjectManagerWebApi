using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ProjectManagerWebApi.Tests
{
    [TestFixture]
    public class HttpResponseTests
    {
        private HttpClient client;

        private HttpResponseMessage response;

        [SetUp]
        public void SetUP()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:52781/api/");
            response = client.GetAsync("GetAllUsers").Result;
        }

        [Test]
        public void GetResponseIsSuccess()
        {
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        [Test]
        public void GetResponseIsJson()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Assert.AreEqual("application/json", response.Content.Headers.ContentType.MediaType);
        }

        [Test]
        public void GetAuthenticationStatus()
        {
            Assert.AreNotEqual(HttpStatusCode.Unauthorized, response.StatusCode);

        }
    }
}
