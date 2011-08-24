using Nancy;
using Xunit;

namespace NancySimpleData.Test
{
    public class HelloWorldTest
    {
        [Fact]
        public void Hello_world_route_should_return_httpstatus_200()
        {
            var browser = new Nancy.Testing.Browser(new Nancy.DefaultNancyBootstrapper());
            var response = browser.Get("/1", (with) => with.HttpRequest());
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
   }
}
