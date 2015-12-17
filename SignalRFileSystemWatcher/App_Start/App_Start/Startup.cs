using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalRFileSystemWatcher.App_Start.Startup))]

namespace SignalRFileSystemWatcher.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Per ulteriori informazioni su come configurare la tua applicazione, visita http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
