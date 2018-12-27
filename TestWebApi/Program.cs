using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace TestWebApi
{
    public class Program
    {
        /// <summary>
        /// Application entrypoint.
        /// </summary>
        /// <param name="args">Command line arguments provided at run time.</param>
        public static void Main(string[] args)
        {
            //     Initializes a new instance of the Microsoft.AspNetCore.Hosting.WebHostBuilder
            //     class with pre-configured defaults.
            CreateWebHostBuilder(args)
                //     Builds an Microsoft.AspNetCore.Hosting.IWebHost which hosts a web application.
                .Build()
                //     Runs a web application and block the calling thread until host shutdown.
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            //     Initializes a new instance of the Microsoft.AspNetCore.Hosting.WebHostBuilder
            //     class with pre-configured defaults.
            WebHost.CreateDefaultBuilder(args)
                //     Specify the startup type to be used by the web host.
                .UseStartup<Startup>();
    }
}
