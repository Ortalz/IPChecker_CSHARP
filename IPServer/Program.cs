using Models;
using Nancy;
using Nancy.Hosting.Self;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManager;
using VirusTotal;

namespace IPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new NancyHost(
                new HostConfiguration() { UrlReservations = new UrlReservations() { CreateAutomatically = true } },
                new Uri("http://localhost:6000")))
            {

                host.Start();
                Console.WriteLine("Running on http://localhost:6000");
                Console.ReadLine();
            }
        }
    }

    public class NancyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<IDataManagerService>(new DataManagerService());
            container.Register<ICheckIPService>(new VirusTotalService());
        }
    }
}
