using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

// Getting file name using FileSystemWatcher and FileSystemEventArgs
// https://docs.microsoft.com/en-us/answers/questions/396971/getting-file-name-using-filesystemwatcher-and-file.html

namespace FilenameFromFileSystemWatcher
{
    class Program
    {
        static AutoResetEvent e = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher(@"G:\Temporary");
            fileSystemWatcher.Filter = "";
            fileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite;
            fileSystemWatcher.Changed += new FileSystemEventHandler(OnChanged);
            fileSystemWatcher.EnableRaisingEvents = true;
            e.WaitOne();
        }

        static public void OnChanged(object obj, FileSystemEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.FullPath);
            e.Set();
        }

    }
}
