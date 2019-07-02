using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SportStore.Infrastructure;

namespace SportStore
{
    public class Program
    {
         public static void Main(string[] args) {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseDefaultServiceProvider(options =>
                    options.ValidateScopes = false)
                .ConfigureLogging((webhostContext, builder) => {
                    builder.AddConfiguration(webhostContext.Configuration.GetSection("Logging"))
                    .AddFilter("Microsoft", LogLevel.Critical);


                    ;
                })
                .Build();
    }
}
