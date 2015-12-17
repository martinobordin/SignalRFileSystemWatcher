using System;
using System.Configuration;
using System.IO;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using SignalRFileSystemWatcher;

[assembly: OwinStartup(typeof(Startup))]

namespace SignalRFileSystemWatcher
{
    public class Startup
    {
        private static readonly Lazy<FileSystemWatcher> Instance = new Lazy<FileSystemWatcher>(() => new FileSystemWatcher(ConfigurationManager.AppSettings["FolderToWatch"])
        {
            IncludeSubdirectories = true
        });

        public void Configuration(IAppBuilder app)
        {
            GlobalHost.DependencyResolver.Register(typeof(FileSystemHub), () => new FileSystemHub(Instance.Value));

            app.MapSignalR();
        }
    }
}
