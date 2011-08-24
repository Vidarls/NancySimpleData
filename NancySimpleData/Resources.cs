using Nancy;

namespace NancySimpleData
{
    public class Resources : NancyModule
    {
        public Resources() : base("resources")
        {
            Get["/style.css"] = p =>
                {
                    return Response.AsCss("Views/Style.css");
                };

            Get["/jquery.js"] = p =>
                {
                    return Response.AsJs("Views/jquery-1.6.2.js");
                };
        }

    }
}
