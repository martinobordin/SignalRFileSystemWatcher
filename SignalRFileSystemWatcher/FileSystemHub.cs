using System;
using System.IO;
using Microsoft.AspNet.SignalR;

namespace SignalRFileSystemWatcher
{
    public class FileSystemHub : Hub
    {
        public FileSystemHub(FileSystemWatcher fileSystemWatcher)
        {
            if (fileSystemWatcher == null)
            {
                throw new ArgumentNullException("fileSystemWatcher");
            }

            fileSystemWatcher.Created += (sender, eventArgs) =>
            {
                this.NotifyEvent(eventArgs);
            };
            fileSystemWatcher.Changed += (sender, eventArgs) =>
            {
                this.NotifyEvent(eventArgs);
            };
            fileSystemWatcher.Deleted += (sender, eventArgs) =>
            {
                this.NotifyEvent(eventArgs);
            };
            fileSystemWatcher.Renamed += (sender, eventArgs) =>
            {
                this.NotifyEvent(eventArgs);
            };
            fileSystemWatcher.Error += (sender, eventArgs) =>
            {
                this.NotifyError(eventArgs);
            };
            fileSystemWatcher.EnableRaisingEvents = true;  
        }


        public void NotifyEvent(FileSystemEventArgs eventArgs)
        {
            this.Clients.Caller.NotifyEvent(new
            {
                ChangeType = eventArgs.ChangeType.ToString(), 
                FileName = $"{DateTime.Now} - {eventArgs.Name}",
            });
        }

        private void NotifyError(ErrorEventArgs eventArgs)
        {
            this.Clients.Caller.NotifyError(new
            {
                Exception = eventArgs.GetException().ToString()
            });
        }
    }
}