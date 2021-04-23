using Microsoft.AspNetCore.Mvc.Testing;
using MyFirstAspNetCoreApp;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MyApp.Tests
{
    public class WebTests
    {
        [Fact]
        public async Task HomePageShouldContainDevelopmentHeading()
        {
            var webApplicationFactory = new WebApplicationFactory<Startup>();
            HttpClient client = webApplicationFactory.CreateClient();

           var response = await client.GetAsync("/");
            var html = await response.Content.ReadAsStringAsync();

            Assert.Contains("<h1>Development</h1>", html);
        }
    }
}
