using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(ProjectHey.Web.Startup))]

namespace ProjectHey.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {         
            app.Map("/signalR", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration { };
                map.RunSignalR(hubConfiguration);
            });
        }
    }
}
