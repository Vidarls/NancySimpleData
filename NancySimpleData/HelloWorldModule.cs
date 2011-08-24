using Nancy;

namespace NancySimpleData
{
    public class HelloWorldModule : NancyModule
    {
        public HelloWorldModule() : base("1")
        {
            Get["/"] = parametere =>
                {
                    return "Hello World";
                };
        }
    }
}
