using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace dotnet_core_test_port
{
  public class Program
  {
    public static void Main(string[] args)
    {
			var config = new ConfigurationBuilder()
			  .AddCommandLine(args)//so the app will get the port # for web server from envi var
			  .Build();
      
      var host = new WebHostBuilder()
        .UseSetting("applicationName", "fortune-teller")
        .UseSetting("detailedErrors", "true")
        .UseEnvironment("Development")
        .CaptureStartupErrors(true)

        .UseConfiguration(config)
        .UseKestrel()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseIISIntegration()
        .UseStartup<Startup>()
        .Build();

      host.Run();
    }
  }
}
