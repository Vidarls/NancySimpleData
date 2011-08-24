using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using Nancy.Hosting.Wcf;

namespace NancySimpleData.WcfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Nancy....");
            var host = new WebServiceHost(new NancyWcfGenericService(),
                              new Uri("http://localhost:8888/"));
            host.AddServiceEndpoint(typeof(NancyWcfGenericService), new WebHttpBinding(), "");
            host.Open();
            Console.WriteLine("Nancy started, press Enter to stop");
            Console.ReadLine();
        }
    }
}
