using Dna;
using Dna.AspNet;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Messenger.Web.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .Build();
        }
        /*public static IWebHost BuildWebHost(string[] args) =>
                .UseDnaFramework(construct =>
                {
                    construct.AddFileLogger();
                })
                .UseStartup<Startup>()
                .Build();*/
    }
}
