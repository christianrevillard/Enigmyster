using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Enigmyster
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }


        //     .UseKestrel(options =>
        //{
        //        options.Listen(IPAddress.Any, 443, listenOptions =>
        //        {
        //            listenOptions.UseHttps("server.pfx", "password");
        //        });
        //    })
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost
                .CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((webHostBuilder, configBuilder) =>
                {
                    IHostingEnvironment env = webHostBuilder.HostingEnvironment;
                    configBuilder.AddJsonFile($"connectionsettings.{env.EnvironmentName}.json");
                });
        }
    }
}