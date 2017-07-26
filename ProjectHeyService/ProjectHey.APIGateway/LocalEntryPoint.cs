using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

namespace ProjectHey.APIGateway
{
    /// <summary>
    /// The Main function can be used to run the ASP.NET Core application locally using the Kestrel webserver.
    /// </summary>
    public class LocalEntryPoint
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseUrls("http://localhost:5000", "http://192.168.0.9:5000")
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();

            //.UseUrls("http://localhost:5000", "http://192.168.0.9:5000")
            //API
            //netsh http add urlacl url=http://192.168.0.9:5000/ user=Iedereen
            //WEB
            //netsh http add urlacl url=http://192.168.0.9:7000/ user=Iedereen

        }
    }
}
