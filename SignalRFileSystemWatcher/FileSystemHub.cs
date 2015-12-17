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
                NotifyEvent(eventArgs);
            };
            fileSystemWatcher.Changed += (sender, eventArgs) =>
            {
                NotifyEvent(eventArgs);
            };
            fileSystemWatcher.Deleted += (sender, eventArgs) =>
            {
                NotifyEvent(eventArgs);
            };
            fileSystemWatcher.Renamed += (sender, eventArgs) =>
            {
                NotifyEvent(eventArgs);
            };
            fileSystemWatcher.Error += (sender, eventArgs) =>
            {
                NotifyError(eventArgs);
            };
            fileSystemWatcher.EnableRaisingEvents = true;  
        }


        public void NotifyEvent(FileSystemEventArgs eventArgs)
        {
            Clients.Caller.NotifyEvent(new
            {
                ChangeType = eventArgs.ChangeType.ToString(), 
                FileName = eventArgs.Name,
            });
        }

        private void NotifyError(ErrorEventArgs eventArgs)
        {
            Clients.Caller.NotifyError(new
            {
                Exception = eventArgs.GetException().ToString()
            });
        }
    }
}