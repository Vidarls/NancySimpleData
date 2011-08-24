using System;
using Nancy.Hosting.Self;

namespace NancySimpleData.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Nancy....");
            var host = new NancyHost(new Uri("http://localhost:8888/"));
            host.Start();
            Console.WriteLine("Nancy started, press Enter to stop");
            Console.ReadLine();
        }
    }
}
